using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class SupportTicket : EntityBase
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsResolved { get; set; }
        public string? AdminResponse { get; set; }

        // Foreign Key to ApplicationUser
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
