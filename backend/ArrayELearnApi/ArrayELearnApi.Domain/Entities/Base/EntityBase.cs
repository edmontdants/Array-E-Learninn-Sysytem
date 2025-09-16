using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrayELearnApi.Domain.Entities.Base
{
    public class EntityBase : MicroEntityBase
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int StatusID { get; set; } = 1;
        public virtual Status Status { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false; // Soft delete flag
    }
}
