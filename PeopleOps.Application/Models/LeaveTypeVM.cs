using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class LeaveTypeModel
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

    public class LeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
