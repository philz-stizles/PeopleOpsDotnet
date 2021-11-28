using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class LeaveRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A name is required")]
        [MaxLength(50, ErrorMessage = "The name should not be more than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The number of days is required")]
        [Display(Name = "Default Number of Days")]
        [Range(1, 25, ErrorMessage = "Number of Days should be between 1 and 25")]
        public int DefaultDays { get; set; }
    }

    public class LeaveRequestVM
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
    }
}
