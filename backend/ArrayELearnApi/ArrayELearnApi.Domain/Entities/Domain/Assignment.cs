using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Assignment : EntityBase
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        
        // FKs
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        // nav props
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
