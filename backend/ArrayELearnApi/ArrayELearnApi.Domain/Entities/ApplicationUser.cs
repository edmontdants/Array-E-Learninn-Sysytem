using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string UserType { get; set; } // "Instructor", "Student", "Admin"
    }
}
