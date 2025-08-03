
namespace ArrayELearnApi.Application.Features.Auth
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; } // "Instructor" or "Student"
    }
}
