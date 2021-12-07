using Microsoft.AspNetCore.Mvc;
using ServerRoomMonitoring.Generator.Config;
using ServerRoomMonitoring.Generator.Models;
using ServerRoomMonitoring.Generator.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRoomMonitoringGenerator.Controllers
{
    [Route("ServerRoom")]
    public class ServerRoomController : Controller
    {
        private readonly IGeneratorService _generatorService;
        private readonly IServerRoom _serverRoom;

        public ServerRoomController(
            IServerRoom serverRoom, 
            IGeneratorService generatorService)
        {
            _serverRoom = serverRoom;
            _generatorService = generatorService;
        }

        [HttpPost]
        [Route("UpdateSensors")]
        public void UpdateSensors([FromBody] IReadOnlyList<SensorConfig> configs, CancellationToken cancellationToken)
        {
            _generatorService.Stop();

            _serverRoom.UpdateSensors(configs);

            _generatorService.Start();
        }
    }
}
