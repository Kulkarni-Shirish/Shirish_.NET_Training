using System.Diagnostics;
using EmployeeLeaveSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveSystem.Controllers
{
    // Handles the main pages like home, privacy, and error
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Inject logger for tracking application events and errors
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Show the home page
        public IActionResult Index()
        {
            return View();
        }

        // Show the privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Handle and display errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Pass the current request ID to the error view
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
