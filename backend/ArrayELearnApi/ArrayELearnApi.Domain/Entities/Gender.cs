using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities
{
    public class Gender : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
