using System.ComponentModel.DataAnnotations;

namespace PaymentValidationSystem.Models
{
    //Model to hold user payment details
    public class PaymentInfo
    {
        //Username of the payer
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string Username { get; set; }

        //Payment mode choosen by user
        [Required(ErrorMessage = "Payment mode is required")]
        public string PaymentMode { get; set; }

        //Credit card number
        [Required(ErrorMessage = "Credit card number is required")]
        [CreditCard(ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }
    }
}