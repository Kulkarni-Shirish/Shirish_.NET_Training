using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserPortalAuthAPI.Models;

namespace UserPortalAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        // This method handles user login and returns a JWT if the credentials are correct
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            // Check if the provided username and password match the dummy credentials
            if (model.Username == "admin" && model.Password == "password")
            {
                // Generate JWT token for the authenticated user
                var token = GenerateJwtToken(model.Username);
                return Ok(new LoginResponse { Token = token });
            }
            // Return 401 Unauthorized if authentication fails
            return Unauthorized();
        }

        // This method generates a JWT token with claims, expiration, issuer, audience, and signing credentials
        private string GenerateJwtToken(string username)
        {
            // Retrieve the JWT key from configuration and validate its length
            var key = _config["Jwt:Key"]!;
            if (string.IsNullOrEmpty(key) || key.Length < 32)
                throw new Exception("JWT Key must be at least 32 characters.");

            // Create symmetric security key and signing credentials using HMAC-SHA256
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims for the token (in this case, the username)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            // Create the JWT token with issuer, audience, claims, expiration, and signing credentials
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Jwt:DurationInMinutes"]!)),
                signingCredentials: credentials
            );

            // Serialize the token to a string and return
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
