using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDateTime _dateTime;

        public HomeController(ILogger<HomeController> logger, IDateTime dateTime,IConfiguration configuration)
        {
            _logger = logger;
            _dateTime = dateTime;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var name = _configuration["Name"];
            var lastName = _configuration["People:LastName"];
            var serverTime = _dateTime.Now;
            if (serverTime.Hour < 12)
            {
                ViewData["Message"] = "Good Morning!";
            }
            else if (serverTime.Hour < 17)
            {
                ViewData["Message"] = "Good Afternoon!";
            }
            else
            {
                ViewData["Message"] = "Good Evening!";
            }
            return View();
        }
    }
}