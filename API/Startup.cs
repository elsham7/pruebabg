using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Utilities;
using API.Filters;

namespace PruebaSamuelAlcivar
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }


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
                        Name = "Departamento de Carrito",
                        Email = "sistemas@carrito.com.ec",
                        Url = new Uri("https://www.carrito.com.ec"),
                    }
                });
            });
        }

        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
        {
            // Config de la Aplicación
            Comun.ConfigApp = Configuration.GetSection("APLICACION");

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

            // Swagger
            AddSwagger(services, env.ApplicationName);


            // Permite capturar el request en la petición POST
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
    }
}
