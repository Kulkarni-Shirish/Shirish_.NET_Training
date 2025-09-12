namespace UserPortalUI.Models
{
    // DTO/ViewModel for capturing user registration details from the UI form
    public class UserRegistrationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int StateId { get; set; }
    }
}
