using ArrayELearnApi.Domain.Entities.Base;
using ArrayELearnApi.Domain.Entities.Domain;

namespace ArrayELearnApi.Domain.Entities.Auth
{
    public class ApplicationUser : IdentityEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public string ProfilePictureUrl { get; set; } // Nullable for optional profile picture

        // Foreign Keys
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }

        // Navigation props related for Students
        public virtual Student Student { get; set; }

        // Navigation props related for Instructors
        public virtual Instructor Instructor { get; set; }
        
        // Navigation props related for Users
        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        
    }
}
