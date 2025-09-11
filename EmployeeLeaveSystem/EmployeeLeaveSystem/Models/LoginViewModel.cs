using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveSystem.Models
{
    // ViewModel for the Login form
    public class LoginViewModel
    {
        // User's email address (required and must be a valid email)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // User's password (required)
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Option to remember the user on this device
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
