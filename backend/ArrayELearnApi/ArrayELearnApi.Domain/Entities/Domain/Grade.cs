
using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Grade : EntityBase
    {
        public double Value { get; set; }
        public string Remarks { get; set; }
        public DateTime GradedAt { get; set; } = DateTime.Now;
    }
}
