using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Enrollment : EntityBase
    {
        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        // Foreign Keys and Navigation Properties
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
