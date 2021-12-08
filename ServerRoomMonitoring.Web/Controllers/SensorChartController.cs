using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;
using ServerRoomLibrary.Services;
using ServerRoomMonitoring.Web.Models;

namespace ServerRoomMonitoring.Web.Controllers
{
    public class SensorChartController : Controller
    {
        private readonly ISensorService _context;

        public SensorChartController(ISensorService context)
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
            var temperatureList = new List<Sensor>();
            
            
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
       
            var voltageList = new List<Sensor>();
            
            foreach (var s in sensorList)
            {
                if (s.SensorType == "Voltage")
                {
                    voltageList.Add(s);
                }
            }
            return Json(voltageList);  
        }  
        [HttpGet]  
        public JsonResult SensorChartHygrometer()  
        {  
            var sensorList =  _context.GetAllSensors();
            var humidityList = new List<Sensor>();
            
            foreach (var s in sensorList)
            {
                if (s.SensorType == "Hygrometer")
                {
                    humidityList.Add(s);
                }
            }
            return Json(humidityList);  
        }  
        [HttpGet]  
        public JsonResult SensorChartCarbonMonoxide()  
        {  
            var sensorList =  _context.GetAllSensors();
       
            var carbonMonoxideList = new List<Sensor>();
            
            foreach (var s in sensorList)
            {
                if (s.SensorType == "CarbonMonoxideSensor")
                {
                    carbonMonoxideList.Add(s);
                }
            }
            return Json(carbonMonoxideList);  
        }  
    }
}