using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveSystem.Models
{
    // ViewModel for the user registration form
    public class RegisterViewModel
    {
        // Full name of the user (required)
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        // User's email address (required and must be valid)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // User's password (required)
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Confirm password field (must match Password)
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
