using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentValidationSystem.Models;

namespace PaymentValidationSystem.Pages
{
    //Razor page model for the Payment form
    public class IndexModel : PageModel
    {
        //Holds the data entered by the user
        [BindProperty]
        public PaymentInfo Payment { get; set; }

        public string Message { get; set; }

        //Handles GET Request
        public void OnGet()
        {
        }
        //Handles POST Request
        public IActionResult OnPost()
        {
            //Result
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Message = $"Thank you {Payment.Username}, your payment via {Payment.PaymentMode} has been recorded.";
            return Page();
        }
    }
}