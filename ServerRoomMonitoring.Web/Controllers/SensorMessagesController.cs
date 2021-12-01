using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;
using ServerRoomMonitoring.Web.Data;

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

    }
}
