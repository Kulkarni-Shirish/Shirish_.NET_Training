using Microsoft.AspNetCore.Mvc;
using UniqueDigitsMvc.Models;
using System.Linq;

namespace UniqueDigitsMvc.Controllers
{
    public class NumberController : Controller
    {
        // GET: Display form
        public IActionResult Index()
        {
            var model = new NumberViewModel();
            return View(model);
        }

        // POST: Process input
        [HttpPost]
        public IActionResult Index(NumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Remove duplicate digits while preserving order
                model.UniqueNumber = string.Concat(model.InputNumber.Distinct());
            }
            return View(model);
        }
    }
}
