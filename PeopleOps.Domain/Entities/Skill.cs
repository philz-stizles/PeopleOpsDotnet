using PeopleOps.Domain.Enums;

namespace PeopleOps.Domain.Entities
{
    public class Skill: EntityBase
    {
        public int Name { get; set; }
        public int Description { get; set; }

        public SkillLevelType Level { get; set; }
    }
}
