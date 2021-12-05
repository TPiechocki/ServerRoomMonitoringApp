using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;
using ServerRoomLibrary.Services;
using ServerRoomMonitoring.Api.Config;
using ServerRoomMonitoring.Api.Listeners;


namespace ServerRoomMonitoring.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SensorsDatabaseSettings>(Configuration.GetSection(nameof(SensorsDatabaseSettings)));
            
            services.AddSingleton<ISensorsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SensorsDatabaseSettings>>().Value);
            
            services.AddControllers();
            
            services.AddConfig(Configuration);
            services.AddHostedService<RabbitMqListener>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServerRoomMonitoring.Api", Version = "v1" });
            });

            services.AddSingleton<ISensorRepository, DBSensorRepository>();
            services.AddSingleton<ISensorService, SensorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerRoomMonitoring.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
