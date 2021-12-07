using Microsoft.Extensions.Hosting;
using ServerRoomMonitoring.Generator.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRoomMonitoringGenerator.Services
{
    public class InitService: BackgroundService
    {
        private readonly IGeneratorService _service;

        public InitService(IGeneratorService service)
        {
            _service = service;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _service.Start();
            return Task.CompletedTask;
        }
    }
}
