using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class ChatMessageArchive : MicroEntityBase
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ArchivedAt { get; set; } = DateTime.Now;

        public string SenderID { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverID { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
