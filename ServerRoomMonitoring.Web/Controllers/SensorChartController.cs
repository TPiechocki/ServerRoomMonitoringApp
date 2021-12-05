using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;
using ServerRoomMonitoring.Web.Models;

namespace ServerRoomMonitoring.Web.Controllers
{
    public class SensorChartController : Controller
    {
        private readonly ISensorRepository _context;

        public SensorChartController(ISensorRepository context)
        {
            _context = context;
        }
        // GET: /<controller>/  
        public IActionResult Index()  
        {  
            return View();  
        }  
        [HttpGet]  
        public JsonResult SensorChartTemperature()  
        {  
            var sensorList =  _context.GetAllSensors();
            var temperatureList = new List<SensorMessage>();
            
            
            foreach (var s in sensorList)
            {
                if (s.SensorType == "Temperature")
                {
                    temperatureList.Add(s);
                }
            }
            return Json(temperatureList);  
        }  
        [HttpGet]  
        public JsonResult SensorChartVoltage()  
        {  
            var sensorList =  _context.GetAllSensors();
       
            var voltageList = new List<SensorMessage>();
            
            foreach (var s in sensorList)
            {
                if (s.SensorType == "Voltage")
                {
                    voltageList.Add(s);
                }
            }
            return Json(voltageList);  
        }  
    }
}