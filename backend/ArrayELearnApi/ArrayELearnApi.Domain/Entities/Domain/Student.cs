using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Student : EntityBase
    {
        // Student-specific props
        public string? ParentName { get; set; }
        public string? ParentPhoneNumber { get; set; }
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }
        
        public string UserID { get; set; }  // Foreign key to Identity
        public virtual ApplicationUser User { get; set; }

        // Student-specific nav props
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
