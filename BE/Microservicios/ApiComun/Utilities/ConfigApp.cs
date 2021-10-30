using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ApiComun.Filters;
using Utilities;
using ViewModel.Seguridad;
using System;
using System.Linq;
using System.Text;

namespace ApiComun.Utilities
{
    public class ConfigApp
    {
        public static void AddSwagger(IServiceCollection services, string nombreApi)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"{nombreApi} {groupName}",
                    Version = groupName,
                    Description = $"{nombreApi}",
                    Contact = new OpenApiContact
                    {
                        Name = "Departamento de Tecnología",
                        Email = "sistemas@carrito.com.ec",
                        Url = new Uri("https://www.carrito.com.ec"),
                    }
                });
            });
        }
        public static void HabilitarServiciosComunes(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            // Config de la Aplicación
            Comun.ConfigApp = configuration.GetSection("APLICACION");

            // Valida autenticación por JWT
            var key = Encoding.ASCII.GetBytes(Comun.ConfigApp.GetSection("SecretKeyJWT").Value);//configuration.GetValue<string>("SecretKeyJWT"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ClockSkew = new System.TimeSpan(0)
                        };
                    });            

            // Comprimir Respuesta
            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

            services.AddControllers(options => options.Filters.Add(new ExceptionFilter(env)));

            // Memoria en Cache
            services.AddDistributedMemoryCache();

            // Swagger
            AddSwagger(services, env.ApplicationName);
            

            // Permite capturar el request en la petición POST
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


            #region Mensajes Asíncronos
            services.AddMassTransit(x =>
            {

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    // configure health checks for this bus instance
                    cfg.UseHealthCheck(provider);

                    string ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
                    string servidorRabbit = Comun.ConfigApp.GetSection("SERVIDOR-RABBIT-" + ambiente).Value;


                    cfg.Host(servidorRabbit);

                }));
            });

            services.AddMassTransitHostedService();
            #endregion
        }        
        public static void HabilitarAplicacionesComunes(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            // Comprimir Respuesta
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", $"{env.ApplicationName} v1"));

        }
        public static LoginUserVM UsuarioSolicitud(string token)
        {
            LoginUserVM user = new LoginUserVM();

            var principal = JWT.ConsultarClaim(token);
            
            user.IdUsuario = Comun.ToInt(principal.Claims.Where(x => x.Type == "IdUsuario").Select(x => x.Value).FirstOrDefault());

            return user;

        }
    }
}
