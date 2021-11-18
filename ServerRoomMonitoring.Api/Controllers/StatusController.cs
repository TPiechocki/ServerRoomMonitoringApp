using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using ServerRoomMonitoring.Api.Config;
using ServerRoomMonitoring.Api.Models;
using ServerRoomMonitoring.Api.Services;

namespace ServerRoomMonitoring.Api.Controllers
{
    [Route("[controller]")]
    public class StatusController : Controller
    {
        private readonly IRabbitConfig _rabbitConfig;

        private ISensorService _sensorService;
        public StatusController(IRabbitConfig rabbitConfig, ISensorService sensorService)
        {
            _rabbitConfig = rabbitConfig;
            _sensorService = sensorService;
        }


        [HttpGet]
        [Route("GetSensors")]
        public List<SensorMessage> GetSensors()
        {
            return _sensorService.GetAllSensors();
        }
        [HttpGet]
        [Route("Queue")]
        public IActionResult Queue()
        {
            var factory = new ConnectionFactory { HostName = _rabbitConfig.HostName };

            try
            {
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                if (channel.IsClosed)
                {
                    throw new Exception("RabbitMQ channel could not be opened.");
                }
                return Ok("Server has RabbitMQ connection.");

            }
            catch (Exception e)
            {
                return Problem(statusCode: 500,
                    title: "RabbitMQ connection error",
                    detail: $"Connection to RabbitMQ failed with: {e.Message}");
            }

        }
    }
}
