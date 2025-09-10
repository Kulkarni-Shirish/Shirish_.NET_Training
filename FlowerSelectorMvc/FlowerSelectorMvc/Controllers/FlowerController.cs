using Microsoft.AspNetCore.Mvc;
using FlowerSelectorMvc.Models;

namespace FlowerSelectorMvc.Controllers
{
    public class FlowerController : Controller
    {
        // GET: Display the form
        public IActionResult Index()
        {
            var model = new FlowerViewModel();
            return View(model);
        }

        // POST: Handle selection
        [HttpPost]
        public IActionResult Index(FlowerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Display message in ViewBag
            ViewBag.Message = $"You selected: {model.SelectedFlower}";
            return View(model);
        }
    }
}
