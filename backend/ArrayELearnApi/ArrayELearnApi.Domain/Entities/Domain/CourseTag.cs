using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class CourseTag : EntityBase
    {
        // Navigation property for many-to-many relationship with Course
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
