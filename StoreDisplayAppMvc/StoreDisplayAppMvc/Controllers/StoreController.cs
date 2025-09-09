using Microsoft.AspNetCore.Mvc;
using StoreDisplayAppMvc.Models;
using System.Collections.Generic;

namespace StoreDisplayAppMvc.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            // Create sample items
            var items = new List<Item>
            {
                new Item { Name = "Laptop", ImageUrl = "/images/laptop.webp", Price = 1200 },
                new Item { Name = "Smartphone", ImageUrl = "/images/phone.png", Price = 800 },
                new Item { Name = "Headphones", ImageUrl = "/images/headphones.webp", Price = 150 }
            };

            // Pass items to the view
            return View(items); 
        }
    }
}
