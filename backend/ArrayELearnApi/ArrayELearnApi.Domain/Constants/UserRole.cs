
namespace ArrayELearnApi.Domain.Constants
{
    public record UserRole
    {
        public const string Owner = nameof(Owner);
        public const string Supervisor = nameof(Supervisor);
        public const string SuperAdmin = nameof(SuperAdmin);
        public const string SupportStaff = nameof(SupportStaff);
        public const string Admin = nameof(Admin);
        public const string Instructor = nameof(Instructor);
        public const string Student = nameof(Student);
    }
}
