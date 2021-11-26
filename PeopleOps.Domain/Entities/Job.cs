using PeopleOps.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PeopleOps.Domain.Entities
{
    public class Job: EntityBase
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public JobDuration Duration { get; set; }
        public Decimal Pay { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual ICollection<Skill> Skils { get; set; }
        public virtual ICollection<Responsibility> Responsibilities { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }
    }
}
