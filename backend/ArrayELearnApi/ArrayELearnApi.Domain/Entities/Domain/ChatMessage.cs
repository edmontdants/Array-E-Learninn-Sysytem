using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class ChatMessage : EntityBase
    {
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }

        public string SenderID { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverID { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
