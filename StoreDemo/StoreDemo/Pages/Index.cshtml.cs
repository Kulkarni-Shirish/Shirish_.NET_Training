using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace StoreDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SelectedItem { get; set; }   // Selected product from dropdown

        public List<SelectListItem> Items { get; set; }   // Dropdown items
        public string SelectedImage { get; set; }         // Product image
        public int Price { get; set; }                    // Product price

        // Store data (Product → Image, Price)
        private readonly Dictionary<string, (string Image, int Price)> _store =
            new Dictionary<string, (string, int)>
            {
                { "Laptop", ("laptop.webp", 50000) },
                { "Mobile", ("phone.png", 20000) },
                { "Headphones", ("headphones.webp", 3000) }
            };

        public void OnGet() => LoadItems();   // Load items on page load

        public void OnPost(string action)
        {
            LoadItems(); // Keep dropdown populated

            if (!string.IsNullOrEmpty(SelectedItem) && _store.ContainsKey(SelectedItem))
            {
                SelectedImage = _store[SelectedItem].Image;  // Show product image

                if (action == "showPrice")
                    Price = _store[SelectedItem].Price;      // Show product price
            }
        }

        private void LoadItems()
        {
            Items = new List<SelectListItem>();
            foreach (var key in _store.Keys)
                Items.Add(new SelectListItem { Text = key, Value = key });
        }
    }
}