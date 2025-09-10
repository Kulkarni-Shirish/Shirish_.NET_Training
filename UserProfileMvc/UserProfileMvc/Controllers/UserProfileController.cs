using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserProfileMvc.Models;

namespace UserProfileMvc.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: formexp
        public IActionResult FormExp()
        {
            ViewBag.Countries = new[] { "India" , "UK", "Canada", "Australia", "Germany" };

            // Initialize model and pre-fill Name from cookie
            var model = new UserProfile();
            if (Request.Cookies.ContainsKey("UserName"))
            {
                model.Name = Request.Cookies["UserName"];
            }

            return View(model);
        }

        // POST: formexp
        [HttpPost]
        public IActionResult FormExp(UserProfile model)
        {
            ViewBag.Countries = new[] { "USA", "UK", "Canada", "Australia", "Germany" };

            if (ModelState.IsValid)
            {
                // Store username in cookie for 30 days
                Response.Cookies.Append("UserName", model.Name, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(30)
                });

                ViewBag.Message = "Form submitted successfully!";
            }

            return View(model);
        }
    }
}
