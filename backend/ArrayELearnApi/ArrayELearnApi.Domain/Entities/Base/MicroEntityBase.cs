using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrayELearnApi.Domain.Entities.Base
{
    public class MicroEntityBase
    {
        [Required]
        public string CREATEDBY { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CREATIONDATE { get; set; } = DateTimeOffset.Now;

        public string MODIFIEDBY { get; set; }

        [Column(TypeName = "datetimeoffset")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? LASTMODIFICATIONDATE { get; set; }
    }
}
