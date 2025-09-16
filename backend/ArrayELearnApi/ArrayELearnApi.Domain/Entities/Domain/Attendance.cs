using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Attendance : EntityBase
    {
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        // FKs and Navigation Props
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
