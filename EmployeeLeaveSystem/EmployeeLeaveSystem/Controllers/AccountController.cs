using EmployeeLeaveSystem.Models;
using EmployeeLeaveSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService emailService)
        {
            _userManager = userManager;       // manage user creation, password, roles
            _signInManager = signInManager;   // handle login and logout functionality
            _emailService = emailService;     // send emails for confirmation and password reset
        }

        // ---------------- REGISTER ----------------
        // Show registration page
        [HttpGet]
        public IActionResult Register() => View();

        // Handle registration form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // generate confirmation link and send email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Account",
                    new { userId = user.Id, token }, Request.Scheme);

                await _emailService.SendEmailAsync(user.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

                return RedirectToAction("RegistrationSuccessful");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // Show registration success page
        public IActionResult RegistrationSuccessful() => View();

        // Handle email confirmation link
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null) return RedirectToAction("Index", "Home");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded) return View("EmailConfirmed");

            return View("Error");
        }

        // ---------------- LOGIN ----------------
        // Show login page
        [HttpGet]
        public IActionResult Login() => View();

        // Handle login form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                    return RedirectToAction("Dashboard", "Admin");  // Admin Dashboard
                else
                    return RedirectToAction("Index", "Home");       // Employee Homepage
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        // ---------------- LOGOUT ----------------
        // Sign the user out
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // ---------------- FORGOT PASSWORD ----------------
        // Show forgot password page
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Handle forgot password submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Do not reveal user existence
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // generate reset link and send email
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account",
                new { token, email = model.Email }, Request.Scheme);

            await _emailService.SendEmailAsync(model.Email, "Reset Password",
                $"Click <a href='{resetLink}'>here</a> to reset your password.");

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        // Show forgot password confirmation page
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // ---------------- RESET PASSWORD ----------------
        // Show reset password form
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
                return RedirectToAction("Index", "Home");

            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }

        // Handle reset password submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // Show reset password confirmation page
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
