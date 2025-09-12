// Represents the response returned by the API after a successful login, containing the JWT token.
namespace UserPortalAuthAPI.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
