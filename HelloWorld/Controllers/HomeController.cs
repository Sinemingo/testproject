using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var name = _configuration["Name"];
            var lastName = _configuration["People:LastName"];
            var serverTime = DateTime.Now;
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