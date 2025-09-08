using Microsoft.AspNetCore.Mvc;

namespace ButtonHoverMvc.Controllers
{
    // This is the main controller for the Home page
    public class HomeController : Controller
    {
        // GET: /Home/Index
        // Handles GET requests to the Home/Index URL
        public IActionResult Index()
        {
            // Returns the Index view to the browser
            return View();
        }
    }
}
