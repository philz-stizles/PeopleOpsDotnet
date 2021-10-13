using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDa { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
