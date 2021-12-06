using Microsoft.AspNetCore.Mvc;

namespace ServerRoomMonitoring.Api.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("This is api");
        }
    }
}