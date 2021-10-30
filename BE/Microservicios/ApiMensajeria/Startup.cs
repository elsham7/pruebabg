using ApiMensajeria.Consumer;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utilities;
using ViewModel.Mensajeria;

namespace ApiMensajeria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Comprimir Respuesta
            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

            // Config de la Aplicación
            Comun.ConfigApp = Configuration.GetSection("APLICACION");

            #region Mensajes Asíncronos
            services.AddMassTransit(x =>
            {
                x.AddConsumer<LogAccesoConsumer>();
                

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    // configure health checks for this bus instance
                    cfg.UseHealthCheck(provider);

                    string ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
                    string servidorRabbit = Comun.ConfigApp.GetSection("SERVIDOR-RABBIT-" + ambiente).Value;


                    cfg.Host(servidorRabbit);

                    #region Saludo
                    cfg.ReceiveEndpoint(ColaAsincronaVM.LogAcceso.ToString(), ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));

                        ep.ConfigureConsumer<LogAccesoConsumer>(provider);
                    });

                    #endregion



                }));
            });

            services.AddMassTransitHostedService();
            #endregion

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Comprimir Respuesta
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Api Mensajeria - Seguros Confianza S.A");
                });
                endpoints.MapControllers();
            });
        }
    }
}
