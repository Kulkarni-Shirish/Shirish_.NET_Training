namespace StoreDisplayAppMvc.Models
{
    
    public class Item
    {
        // The name of the product (e.g., Laptop, Smartphone, etc.)
        public string Name { get; set; }

        // The relative URL path to the product's image (stored in wwwroot/Images/)
        public string ImageUrl { get; set; }

        // The price of the product in USD or any currency
        public decimal Price { get; set; }
    }
}
