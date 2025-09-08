using Microsoft.AspNetCore.Mvc;
using AddSubtractMvc.Models;

namespace AddSubtractMvc.Controllers
{
    // HomeController handles the Add/Subtract calculator pages
    public class HomeController : Controller
    {
        // GET: /Home/Index
        // Returns the initial view with an empty CalculatorViewModel
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        // POST: /Home/Index
        // Handles form submission, performs calculation, and returns the updated model
        [HttpPost]
        public IActionResult Index(CalculatorViewModel model)
        {
            // Check which operation the user selected and calculate the result
            if (model.Operation == "Add")
                model.Result = model.Number1 + model.Number2;
            else if (model.Operation == "Subtract")
                model.Result = model.Number1 - model.Number2;

            // Return the same view with the model containing the result
            return View(model);
        }
    }
}
