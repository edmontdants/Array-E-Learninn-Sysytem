using ArrayELearnApi.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrayELearnApi.Domain.Entities.Base
{
    public class IdentityEntityBase : IdentityUser
    {
        [Column(TypeName = "nvarchar(450)")]
        public string CREATEDBY { get; set; }
        public virtual ApplicationUser CREATEDBYUSER { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CREATIONDATE { get; set; } = DateTimeOffset.Now;

        [Column(TypeName = "nvarchar(450)")]
        public string? MODIFIEDBY { get; set; }
        public virtual ApplicationUser MODIFIEDBYUSER { get; set; }

        [Column(TypeName = "datetimeoffset")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? LASTMODIFICATIONDATE { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false; // Soft delete flag
        
        // Reverse navigation (users I created/modified)
        public virtual ICollection<ApplicationUser> CREATEDUSERS { get; set; }
        public virtual ICollection<ApplicationUser> MODIFIEDUSERS { get; set; }
    }
}
