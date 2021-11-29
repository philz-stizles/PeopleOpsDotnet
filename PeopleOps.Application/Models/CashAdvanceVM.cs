using PeopleOps.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class CashAdvanceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Range(5000, 50000.00, ErrorMessage = "Amount must be minimum of 5,000, but less than 50,000")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [MinLength(10, ErrorMessage = "Comment should be greater than 10 characters")]
        public string Comment { get; set; }
    }

    public class CashAdvanceVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Approval Status")]
        public ApprovalStatus ApprovalStatus { get; set; }
        public string Comment { get; set; }
        public string CreatedDate { get; set; }
    }
}
