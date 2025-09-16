using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Fee : EntityBase
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public string Description { get; set; }

        // FKs and Navigation properties
        public int? StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int? InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
