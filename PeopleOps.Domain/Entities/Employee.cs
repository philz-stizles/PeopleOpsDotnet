using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PeopleOps.Domain.Entities
{
    [Table("Employees")]
    public class Employee : IdentityUser
    {
        // NotMapped - This property will not be mapped to a database table
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string Avatar { get; set; }
        public virtual JobRole Role { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Skill> Skils { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
