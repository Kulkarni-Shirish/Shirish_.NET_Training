using EmployeeLeaveSystem.Data;
using EmployeeLeaveSystem.Models;
using EmployeeLeaveSystem.Services;   // For EmailService
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem.Controllers
{
    // Handles leave requests for employees and management actions
    [Authorize]
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EmailService _emailService;

        // Inject DB context, user manager, and email service
        public LeaveController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            EmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        // ---------------- Employee Actions ----------------

        // Show all leave requests for the logged-in employee
        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var leaves = await _context.LeaveRequests
                .Where(l => l.EmployeeId == user.Id)
                .OrderByDescending(l => l.StartDate)
                .ToListAsync();

            return View(leaves);
        }

        // Show leave creation form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handle leave submission by employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                // Assign employee info and set status to Pending
                model.EmployeeId = user.Id;
                model.Employee = user;
                model.Status = "Pending";

                _context.LeaveRequests.Add(model);
                await _context.SaveChangesAsync();

                // Send confirmation email to employee
                if (!string.IsNullOrEmpty(user.Email))
                {
                    await _emailService.SendEmailAsync(
                        user.Email,
                        "Leave Request Submitted",
                        $"Hello {user.FullName},<br/><br/>" +
                        $"Your leave request from <b>{model.StartDate:dd-MM-yyyy}</b> " +
                        $"to <b>{model.EndDate:dd-MM-yyyy}</b> is <span style='color:orange'><b>Pending Approval</b></span>.<br/><br/>" +
                        $"Regards,<br/>Leave Management Team"
                    );
                }

                // Notify managers and admins about new leave request
                var managers = await _userManager.GetUsersInRoleAsync("Manager");
                var admins = await _userManager.GetUsersInRoleAsync("Admin");
                var recipients = managers.Concat(admins).ToList();

                foreach (var manager in recipients)
                {
                    if (!string.IsNullOrEmpty(manager.Email))
                    {
                        await _emailService.SendEmailAsync(
                            manager.Email,
                            "New Leave Request Submitted",
                            $"Hello {manager.UserName},<br/><br/>" +
                            $"Employee <b>{user.FullName}</b> ({user.Email}) " +
                            $"applied for leave from <b>{model.StartDate:dd-MM-yyyy}</b> " +
                            $"to <b>{model.EndDate:dd-MM-yyyy}</b>.<br/>Reason: {model.Reason}<br/><br/>" +
                            $"Please review the request in the system.<br/><br/>" +
                            $"Regards,<br/>Leave Management System"
                        );
                    }
                }

                TempData["SuccessMessage"] = "Leave applied successfully!";
                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        // Show details of a specific leave request
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var leave = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leave == null)
                return NotFound();

            return View(leave);
        }

        // ---------------- Manager/Admin Actions ----------------

        // Show all pending leave requests for managers/admins
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> PendingRequests()
        {
            var pendingLeaves = await _context.LeaveRequests
                .Include(l => l.Employee)
                .Where(l => l.Status == "Pending")
                .OrderBy(l => l.StartDate)
                .ToListAsync();

            return View(pendingLeaves);
        }

        // Approve a leave request and notify employee
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var leave = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leave == null) return NotFound();

            leave.Status = "Approved";
            _context.Update(leave);
            await _context.SaveChangesAsync();

            // Notify employee about approval
            if (!string.IsNullOrEmpty(leave.Employee?.Email))
            {
                await _emailService.SendEmailAsync(
                    leave.Employee.Email,
                    "Leave Request Approved",
                    $"Hello {leave.Employee.UserName},<br/><br/>" +
                    $"Your leave request from <b>{leave.StartDate:dd-MM-yyyy}</b> " +
                    $"to <b>{leave.EndDate:dd-MM-yyyy}</b> has been <span style='color:green'><b>Approved</b></span>.<br/><br/>" +
                    $"Regards,<br/>Leave Management Team"
                );
            }

            return RedirectToAction(nameof(PendingRequests));
        }

        // Reject a leave request and notify employee
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var leave = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leave == null) return NotFound();

            leave.Status = "Rejected";
            _context.Update(leave);
            await _context.SaveChangesAsync();

            // Notify employee about rejection
            if (!string.IsNullOrEmpty(leave.Employee?.Email))
            {
                await _emailService.SendEmailAsync(
                    leave.Employee.Email,
                    "Leave Request Rejected",
                    $"Hello {leave.Employee.UserName},<br/><br/>" +
                    $"Your leave request from <b>{leave.StartDate:dd-MM-yyyy}</b> " +
                    $"to <b>{leave.EndDate:dd-MM-yyyy}</b> has been <span style='color:red'><b>Rejected</b></span>.<br/><br/>" +
                    $"Regards,<br/>Leave Management Team"
                );
            }

            return RedirectToAction(nameof(PendingRequests));
        }
    }
}
