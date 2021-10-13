using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class NotificationCreateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Default Number of Days")]
        [Range(1, 25, ErrorMessage = "Number of Days should be between 1 and 25")]
        public string DefaultDays { get; set; }
    }

    public class NotificationVM
    {
    }
}
