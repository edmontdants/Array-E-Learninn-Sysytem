using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
