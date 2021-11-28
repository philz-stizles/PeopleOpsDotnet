using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleOps.Domain.Entities
{
    [Table("LeaveAllocations")]
    public class LeaveAllocation: EntityBase
    {
        [Required]
        public int NumberOfDays { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
