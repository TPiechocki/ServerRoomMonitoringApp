using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Services;

namespace ServerRoomMonitoringApp.Web.Pages.SensorMessages
{
    public class IndexModel : PageModel
    {
        /*private readonly ServerRoomMonitoringApp.Web.Data.ServerRoomMonitoringAppWebContext _context;

        public IndexModel(ServerRoomMonitoringApp.Web.Data.ServerRoomMonitoringAppWebContext context)
        {
            _context = context;
        }*/
        private readonly ISensorService _context;
        public IndexModel(ISensorService context)
        {
            _context = context;
        }

        public IList<SensorMessage> SensorMessage { get;set; }

        public void OnGetAsync()
        {
            SensorMessage = _context.GetAllSensors();
        }

        public IActionResult OnPostAsync()
        {
            return RedirectToPage("/SensorMessages/Index");
        }
    }
}
