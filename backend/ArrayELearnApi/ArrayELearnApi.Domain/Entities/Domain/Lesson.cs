using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Lesson : EntityBase
    {
        public string Title { get; set; }
        public string ContentUrl { get; set; }

        // FKs & Navigation props
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
