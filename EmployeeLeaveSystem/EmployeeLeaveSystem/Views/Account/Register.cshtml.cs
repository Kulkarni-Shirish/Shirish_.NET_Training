using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EmployeeLeaveSystem.Models;
using EmployeeLeaveSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeLeaveSystem.Areas.Identity.Pages.Account
{
    // Razor Page model for user registration
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;

        // Inject UserManager, SignInManager, and EmailService
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        // Bind input data from the form
        [BindProperty]
        public InputModel Input { get; set; }

        // Input model for registration form
        public class InputModel
        {
            [Required]
            public string FullName { get; set; } // Full name of the user

            [Required]
            [EmailAddress]
            public string Email { get; set; } // User's email address

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } // Password

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; } // Confirm password
        }

        // Handle GET request (display registration page)
        public void OnGet()
        {
        }

        // Handle POST request (process registration)
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Create new application user
            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                FullName = Input.FullName
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                // Generate email confirmation token and link
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Page("/Account/ConfirmEmail", null, new { userId = user.Id, token }, Request.Scheme);

                // Send confirmation email
                await _emailService.SendEmailAsync(user.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

                return RedirectToPage("/Account/RegistrationSuccessful");
            }

            // Add errors to model state to display in the view
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
