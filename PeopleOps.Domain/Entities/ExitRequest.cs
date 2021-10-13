using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleOps.Domain.Entities
{
    public class ExitRequest: EntityBase
    {
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public string Reason { get; set; }

        [NotMapped]
        public TimeSpan DaysLeft { get; set; }
        public DateTime When { get; set; }
    }
}
