using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using UserPortalAuthUI.Models;

namespace UserPortalAuthUI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Handles the login form submission and sends credentials to the API
        public async Task<IActionResult> OnPostAsync()
        {
            var loginRequest = new LoginRequest { Username = Username, Password = Password };
            var client = _httpClientFactory.CreateClient();

            // Serialize login request to JSON and set content type
            var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Call the API login endpoint
            var response = await client.PostAsync("https://localhost:7009/api/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Store the JWT token in session for subsequent API calls
                if (loginResponse != null)
                    HttpContext.Session.SetString("JWToken", loginResponse.Token);

                Message = "Login successful!";
            }
            else
            {
                Message = "Login failed!";
            }

            return Page();
        }
    }
}
