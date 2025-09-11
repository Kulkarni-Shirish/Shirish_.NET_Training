using EmployeeLeaveSystem.Data;
using EmployeeLeaveSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem.Controllers.Api
{
    [Route("api/leave")]
    [ApiController]
    public class LeaveApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveApiController(ApplicationDbContext context)
        {
            _context = context; // save DB context for use in methods
        }

        // Get all leave requests along with employee info
        [HttpGet]
        public async Task<IActionResult> GetLeaves()
        {
            var leaves = await _context.LeaveRequests
                .Include(l => l.Employee)
                .ToListAsync();

            return Ok(leaves);
        }

        // Get a single leave request by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeave(int id)
        {
            var leave = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leave == null)
                return NotFound();

            return Ok(leave);
        }

        // Submit a new leave request, status is pending initially
        [HttpPost]
        public async Task<IActionResult> ApplyLeave([FromBody] LeaveRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.Status = "Pending";
            _context.LeaveRequests.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeave), new { id = model.Id }, model);
        }

        // Approve a leave request by updating its status
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null)
                return NotFound();

            leave.Status = "Approved";
            await _context.SaveChangesAsync();

            return Ok(leave);
        }

        // Reject a leave request by updating its status
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null)
                return NotFound();

            leave.Status = "Rejected";
            await _context.SaveChangesAsync();

            return Ok(leave);
        }
    }
}
