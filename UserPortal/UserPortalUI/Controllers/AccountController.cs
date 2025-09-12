using Microsoft.AspNetCore.Mvc;
using UserPortalUI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace UserPortalUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        // 1️⃣ Constructor: Initializes HttpClient and sets the API base URL from configuration
        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            // Get the API base URL from appsettings.json
            var apiBaseUrl = configuration["ApiBaseUrl"];
            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                // Throw an error if the API URL is missing
                throw new Exception("API Base URL is not configured in appsettings.json");
            }

            _httpClient.BaseAddress = new Uri(apiBaseUrl);
        }

        // 2️⃣ GET: Show the registration form to the user
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // 3️⃣ POST: Handles form submission and sends user data to the API
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model); // If the form is invalid, redisplay it

            try
            {
                // Convert the model into JSON to send in the HTTP request
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint
                var response = await _httpClient.PostAsync("api/users/register", content);

                if (response.IsSuccessStatusCode)
                {
                    // Show success message if API responds positively
                    ViewBag.Message = "User registered successfully!";
                    return View();
                }
                else
                {
                    // Read API error response (if any) and show to user
                    var error = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = $"Error while registering user: {error}";
                    return View(model);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handles cases where API is unreachable
                ViewBag.Message = $"Could not connect to API: {ex.Message}";
                return View(model);
            }
        }
    }
}
