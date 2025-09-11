using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveSystem.Models
{
    // ViewModel for the Forgot Password form
    public class ForgotPasswordViewModel
    {
        // User's email address (required and must be valid)
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
