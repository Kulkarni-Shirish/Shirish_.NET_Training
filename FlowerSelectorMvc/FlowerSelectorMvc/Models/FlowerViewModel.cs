using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerSelectorMvc.Models
{
    public class FlowerViewModel
    {
        [Required(ErrorMessage = "Please select a flower")]
        public string SelectedFlower { get; set; } = string.Empty; // Stores selected flower

        public List<string> Flowers { get; set; } = new List<string>
        {
            "Rose",
            "Tulip",
            "Lily",
            "Sunflower",
            "Orchid",
            "Daisy"
        };
    }
}
