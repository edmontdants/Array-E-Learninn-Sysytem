using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Complaint : EntityBase
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Open"; // Open, In Progress, Resolved

        // Foreign Key to Student
        public int UserId { get; set; }
        public virtual Student User { get; set; } = null!;
    }
}
