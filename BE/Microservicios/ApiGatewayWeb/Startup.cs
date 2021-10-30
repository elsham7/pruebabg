using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ApiGatewayWeb.Handler;

namespace ApiGatewayWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // Comprimir Respuesta
            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

            // Gateway
            services.AddOcelot()
                    .AddDelegatingHandler<BlackListHandler>()// Controla la autorización
                    .AddCacheManager(settings => settings.WithDictionaryHandle());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //para un dominio cruzado;
            app.UseCors(x => x
               //.WithOrigins("http://localhost:3001") // origen especifico
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // permite de cualquier origen
               .AllowCredentials()
               );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Comprimir Respuesta
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("carrito");
                });
            });

            // Gateway
            app.UseOcelot().Wait();
        }
    }
}
