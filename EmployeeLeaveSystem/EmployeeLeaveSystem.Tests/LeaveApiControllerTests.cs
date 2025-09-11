using EmployeeLeaveSystem.Controllers.Api;
using EmployeeLeaveSystem.Data;
using EmployeeLeaveSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem.Tests
{
    [TestFixture]
    public class LeaveApiControllerTests
    {
        private ApplicationDbContext _context;
        private LeaveApiController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "LeaveTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _controller = new LeaveApiController(_context);

            // Clean database before each test
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            // Seed test LeaveRequest
            _context.LeaveRequests.Add(new LeaveRequest
            {
                Id = 1,
                EmployeeId = "emp1",
                Status = "Pending",
                Reason = "Vacation"
            });
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task ApproveLeave_ShouldUpdateStatusToApproved()
        {
            // Act
            var result = await _controller.ApproveLeave(1) as OkObjectResult;
            var leave = await _context.LeaveRequests.FindAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(leave.Status, Is.EqualTo("Approved"));
        }

        [Test]
        public async Task RejectLeave_ShouldUpdateStatusToRejected()
        {
            // Act
            var result = await _controller.RejectLeave(1) as OkObjectResult;
            var leave = await _context.LeaveRequests.FindAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(leave.Status, Is.EqualTo("Rejected"));
        }
    }
}
