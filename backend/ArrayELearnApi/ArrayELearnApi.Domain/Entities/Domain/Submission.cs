using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Submission : EntityBase
    {
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        public string FileUrl { get; set; }
        public string? Feedback { get; set; }

        // Key Relationships
        public int GradeID { get; set; }
        public virtual Grade Grade { get; set; }

        public int AssignmentID { get; set; }
        public virtual Assignment Assignment { get; set; }
        
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
