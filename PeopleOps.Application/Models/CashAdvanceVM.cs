using PeopleOps.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class CashAdvanceCreateVM
    {
        public int Id { get; set; }
        [Required]
        [Range(5000, 50000.00)]
        public decimal Amount { get; set; }
        [Required]
        public string Comment { get; set; }
    }

    public class CashAdvanceVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Approval Status")]
        public ApprovalStatus ApprovalStatus { get; set; }
        public string Comment { get; set; }
    }
}
