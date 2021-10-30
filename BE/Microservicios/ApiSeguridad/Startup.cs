using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiComun.Utilities;

namespace ApiSeguridad
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
            ConfigApp.HabilitarServiciosComunes(services, Configuration, Environment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigApp.HabilitarAplicacionesComunes(app, env);
        }
    }
}
