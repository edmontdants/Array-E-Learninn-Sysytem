using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Instructor : EntityBase
    {
        // Instructor-specific props
        public string? Designation { get; set; }
        public string? Education { get; set; }

        // Foreign key to Identity        
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        // Instructor-specific nav props
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
