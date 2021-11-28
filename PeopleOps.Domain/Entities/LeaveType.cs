using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleOps.Domain.Entities
{
    [Table("LeaveTypes")]
    public class LeaveType: EntityBase
    {
        [Column("Name")]
        /* [Index("INDEX_NAME", IsUnique = true)]*/
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int DefaultDays { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
