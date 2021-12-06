using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerRoomMonitoring.Generator.Config;
using ServerRoomMonitoring.Generator.Messaging;
using ServerRoomMonitoring.Generator.Models;
using ServerRoomMonitoring.Generator.Services;

namespace ServerRoomMonitoring.Generator
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
            services.AddOptions();

            services.Configure<RabbitConfig>(Configuration.GetSection("RabbitMq"));
            services.AddSingleton<ISensorQueue, SensorQueue>();
            services.AddSingleton<IServerRoom, ServerRoom>();
            services.AddSingleton<IStopper, Stopper>();
            services.AddHostedService<GeneratorBackgroundService>();

            services.AddControllers();

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        
    }
}