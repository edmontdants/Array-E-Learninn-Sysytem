using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class NotificationMessage : EntityBase
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}