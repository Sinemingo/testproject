using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDateTime _dateTime;

        public HomeController(ILogger<HomeController> logger, IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public IActionResult Index()
        {
<<<<<<< HEAD
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
=======

>>>>>>> 5794a1d841780e8361b0716cf2097028d2cc8c9f
            return View();
        }
    }
}