using ArrayELearnApi.Domain.Entities.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrayELearnApi.Domain.Entities.Base
{
    public class MicroEntityBase
    {
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string CREATEDBY { get; set; }

        [ForeignKey(nameof(CREATEDBY))]
        public virtual ApplicationUser CREATEDBYUSER { get; set; }
        
        [Required]
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CREATIONDATE { get; set; } = DateTimeOffset.Now;

        [Column(TypeName = "nvarchar(450)")]
        public string? MODIFIEDBY { get; set; }
        
        [ForeignKey(nameof(MODIFIEDBY))]
        public virtual ApplicationUser MODIFIEDBYUSER { get; set; }
        
        [Column(TypeName = "datetimeoffset")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? LASTMODIFICATIONDATE { get; set; }
    }
}
