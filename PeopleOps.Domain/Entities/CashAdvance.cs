using PeopleOps.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleOps.Domain.Entities
{
    public class CashAdvance: EntityBase
    {
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Comment { get; set; }

        [Required]
        [DefaultValue(ApprovalStatus.Pending)]
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
