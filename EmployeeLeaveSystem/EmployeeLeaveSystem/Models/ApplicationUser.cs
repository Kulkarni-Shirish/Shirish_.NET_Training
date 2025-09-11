using Microsoft.AspNetCore.Identity;

namespace EmployeeLeaveSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // FullName is required for registration
        public required string FullName { get; set; }
    }
}
