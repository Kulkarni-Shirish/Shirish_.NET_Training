namespace UserPortalAPI.Models
{
    //  DTO class for user registration - used to receive data from the UI or API client
    public class UserRegistrationDto
    {
        //  Username of the new user
        public string Username { get; set; }

        //  Password of the new user
        public string Password { get; set; }

        
        public string PhoneNumber { get; set; }

        //  Email address of the user
        public string Email { get; set; }

        
        public int StateId { get; set; }
    }
}
