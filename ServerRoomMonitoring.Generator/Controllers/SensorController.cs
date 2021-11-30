using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ServerRoomMonitoring.Generator.Models;
using ServerRoomMonitoring.Generator.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRoomMonitoringGenerator.Controllers
{
    [Route("Sensor")]
    public class SensorController : Controller
    {
        private IStopper _stopper;
        
        public SensorController(IStopper stopper)
        {
            _stopper = stopper;
        }

        [HttpGet]
        [Route("Stop")]
        public void Stop()
        {
            _stopper.Stopped = true;
        }
    }
}
