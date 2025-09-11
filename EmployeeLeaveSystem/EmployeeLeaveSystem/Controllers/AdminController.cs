using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveSystem.Controllers
{
    // Only users in the Admin role can access this controller
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // Show the admin dashboard page
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
