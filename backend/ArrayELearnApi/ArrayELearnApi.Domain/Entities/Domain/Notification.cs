using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Notification : EntityBase
    {
        public bool IsRead { get; set; } = false; // Track if notification has been read
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public string RecipientID { get; set; }  // FK to ApplicationUser
        public virtual ApplicationUser Recipient { get; set; }

        public int MessageID { get; set; }  // FK to NotificationMessage
        public virtual NotificationMessage Message { get; set; }

    }
}