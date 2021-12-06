using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ServerRoomMonitoring.Generator.Models;
using ServerRoomMonitoring.Generator.Services;
using ServerRoomMonitoringGenerator.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRoomMonitoringGenerator.Controllers
{
    [Route("Sensor")]
    public class SensorController : Controller
    {
        private IStopper _stopper;
        private IGeneratorBackgroundService _service;
        
        public SensorController(IStopper stopper, IGeneratorBackgroundService service)
        {
            _stopper = stopper;
            _service = service;
        }

        [HttpGet]
        [Route("Stop")]
        public void Stop()
        {
            _stopper.Stopped = true;
        }

        [HttpGet]
        [Route("Start")]
        public void Start()
        {
            _service.Start();
            _stopper.Stopped = false;

        }

    }
}
