using EmployeeLeaveSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveSystem.Data
{
    // Database context for the application, includes Identity and custom tables
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Pass options to the base IdentityDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Represents the LeaveRequests table in the database
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
