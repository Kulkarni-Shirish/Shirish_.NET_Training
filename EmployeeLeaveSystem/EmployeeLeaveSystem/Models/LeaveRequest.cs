using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveSystem.Models
{
    // Represents a leave request submitted by an employee
    public class LeaveRequest
    {
        // Primary key for the leave request
        public int Id { get; set; }

        // ID of the employee submitting the leave (skip form validation)
        [ValidateNever]
        public string EmployeeId { get; set; }

        // Navigation property for the employee (skip form validation)
        [ValidateNever]
        public ApplicationUser Employee { get; set; }

        // Start date of the leave (required)
        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        // End date of the leave (required)
        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        // Reason for taking leave (required)
        [Required(ErrorMessage = "Reason is required")]
        public string Reason { get; set; }

        // Current status of the leave request, defaults to Pending
        public string Status { get; set; } = "Pending";
    }
}
