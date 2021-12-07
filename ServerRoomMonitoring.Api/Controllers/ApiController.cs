using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [HttpGet]
        [Route("filtrC")]
        public IActionResult FiltrC(
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
            List<Sensor> sensorList = _sensorService.GetByAllParamsSensors(no,sensorType,value,sensorUnit,date);
            var lines = new List<string>();
            var header = "Sensor,id,type,value,unit,data,";
            lines.Add(header);
            String s = String.Join(",", sensorList.Select(x => x.ToString()).ToArray());
            var valueLines = sensorList.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            return Ok( lines.ToArray() );
            
            
        }
        
        

        [HttpGet]
        [Route("sortType")]
        public List<Sensor> SortType([FromQuery(Name = "type")] string type)
        {
            return _sensorService.GetSortedByTypeAsc(type);
        }
        
        
        [HttpGet]
        [Route("sort")]
        public List<Sensor> Sort(
                [FromQuery(Name = "id")] string sensorNo,
                [FromQuery(Name = "type")] string sensorType,
                [FromQuery(Name = "value")] string sensorValue,
                [FromQuery(Name = "unit")] string sensorUnit,
                [FromQuery(Name = "data")] string sensorDate,
                [FromQuery(Name = "sortBy")] string sortBy,
                [FromQuery(Name = "sortMode")] string sortMode
            )

        {
            int? no = String.IsNullOrEmpty(sensorNo) ? null : int.Parse(sensorNo) ;
            int? value = String.IsNullOrEmpty(sensorValue) ? null : int.Parse(sensorValue) ;
            DateTime? date = String.IsNullOrEmpty(sensorDate) ? null : DateTime.Parse(sensorDate);
            
            return _sensorService.GetSortedByAllParamsSensors(no, sensorType, value, sensorUnit, date, sortBy, sortMode);
        }
        
        
        [HttpGet]
        [Route("addMany")]
        public IActionResult AddMany()
        {
           _sensorService.AddManyDev();
           return Ok("Dodano - DEV");
        }
        
        
        
        
    }
}