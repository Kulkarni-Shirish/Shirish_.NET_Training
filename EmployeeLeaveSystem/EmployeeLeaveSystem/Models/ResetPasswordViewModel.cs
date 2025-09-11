using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveSystem.Models
{
    // ViewModel for resetting a user's password
    public class ResetPasswordViewModel
    {
        // User's email address (required and must be valid)
        [Required, EmailAddress]
        public string Email { get; set; }

        // New password (required)
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        // Confirm new password (must match Password)
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        // Token used to verify password reset request
        public string Token { get; set; }
    }
}
