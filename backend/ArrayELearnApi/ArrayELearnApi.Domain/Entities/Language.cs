using ArrayELearnApi.Domain.Entities.Base;
using ArrayELearnApi.Domain.Entities.Domain;

namespace ArrayELearnApi.Domain.Entities
{
    public class Language : EntityBase
    {
        public string Name { get; set; } // e.g., Arabic English, Spanish, French
        public string Code { get; set; } // e.g., ar, en, es, fr
    }
}
