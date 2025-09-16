using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Feedback : EntityBase
    {
        public int Rating { get; set; } // e.g., 1 to 5 stars
        public string Description { get; set; }

        // FKs & Navigation properties
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
