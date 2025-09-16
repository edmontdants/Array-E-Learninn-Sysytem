using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrayELearnApi.Domain.Entities.Base
{
    public class IdentityEntityBase : IdentityUser
    {
        [Required]
        public int CREATEDBY { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CREATIONDATE { get; set; } = DateTimeOffset.Now;

        public int? MODIFIEDBY { get; set; }

        [Column(TypeName = "datetimeoffset")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? LASTMODIFICATIONDATE { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false; // Soft delete flag
    }
}
