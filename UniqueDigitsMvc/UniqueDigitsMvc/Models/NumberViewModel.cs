using System.ComponentModel.DataAnnotations;

namespace UniqueDigitsMvc.Models
{
    public class NumberViewModel
    {
        [Required(ErrorMessage = "Please enter a 9-digit number")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Number must be exactly 9 digits")]
        public string InputNumber { get; set; } = string.Empty; // User input

        public string UniqueNumber { get; set; } = string.Empty; // Output
    }
}
