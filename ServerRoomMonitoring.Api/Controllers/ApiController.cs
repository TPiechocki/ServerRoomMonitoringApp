using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;
using ServerRoomLibrary.Services;
using ServerRoomMonitoring.Api.Config;

namespace ServerRoomMonitoring.Api.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IRabbitConfig _rabbitConfig;

        private ISensorService _sensorService;
        
        public ApiController(IRabbitConfig rabbitConfig, ISensorService sensorService)
        {
            _rabbitConfig = rabbitConfig;
            _sensorService = sensorService;
        }
        

        public IActionResult Index()
        {
            return Ok("This is api");
        }

        [HttpGet]
        [Route("filtr")]
        public List<Sensor> Filtr(
            [FromQuery(Name = "id")] string sensorNo,
            [FromQuery(Name = "type")] string sensorType,
            [FromQuery(Name = "value")] string sensorValue,
            [FromQuery(Name = "unit")] string sensorUnit,
            [FromQuery(Name = "data")] string sensorDate
            )
            //api?q1=1&q2=2&q3=3
        {
            
            int? no = String.IsNullOrEmpty(sensorNo) ? null : int.Parse(sensorNo) ;
            int? value = String.IsNullOrEmpty(sensorValue) ? null : int.Parse(sensorValue) ;
            DateTime? date = String.IsNullOrEmpty(sensorDate) ? null : DateTime.Parse(sensorDate);
         
            //No validation!
            return _sensorService.GetByAllParamsSensors(no,sensorType,value,sensorUnit,date);
            
            
        }
    }
}