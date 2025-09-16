using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class NotificationArchive : MicroEntityBase
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ArchivedAt { get; set; } = DateTime.Now;

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}