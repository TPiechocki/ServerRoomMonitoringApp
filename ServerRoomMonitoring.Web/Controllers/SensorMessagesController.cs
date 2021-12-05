﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;


namespace ServerRoomMonitoring.Web.Controllers
{
    public class SensorMessagesController : Controller
    {
        private readonly ISensorRepository _context;

        public SensorMessagesController(ISensorRepository context)
        {
            _context = context;
        }

        // GET: SensorMessages
        public IActionResult Index()
        {
            return View(_context.GetAllSensors());
        }

        [HttpPost]
        public IActionResult Reload()
        {
            return View("Index", _context.GetAllSensors());
        }
        public IActionResult DownloadCsv()
        {
            var csvString = GenerateCSVString();  
            var fileName = "CsvData " + DateTime.Now.ToString() + ".csv";  
            return File(new System.Text.UTF8Encoding().GetBytes(csvString), "text/csv", fileName);  
        }
        private string GenerateCSVString()
        {
            var sensors = _context.GetAllSensors();
            StringBuilder sb = new StringBuilder(); 
            sb.Append("Id,");
            sb.Append("SensorType,");
            sb.Append("Value,");  
            sb.Append("Unit,");  
            sb.Append("Date");  
            sb.AppendLine();  
            foreach (var sensor in sensors)
            {
                sb.Append(sensor.Id);  
                sb.Append(',');  
                sb.Append(sensor.SensorType + ',');  
                sb.Append(sensor.Value);  
                sb.Append(',');  
                sb.Append(sensor.Unit + ',');  
                sb.Append(sensor.Date);  
                sb.AppendLine();  
            }  
            return sb.ToString();  
        }
        public IActionResult DownloadJson()
        {
            var sensors = _context.GetAllSensors();
            var jsonstr = System.Text.Json.JsonSerializer.Serialize(sensors);
            byte[] byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(jsonstr);
              
            return File(byteArray, "application/force-download", "JsonData"+ DateTime.Now.ToString() + ".json");
        }
    }
}
