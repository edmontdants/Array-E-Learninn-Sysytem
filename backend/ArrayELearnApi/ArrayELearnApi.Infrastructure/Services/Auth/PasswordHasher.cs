using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Infrastructure.Services.Auth
{
    public class PasswordHasher(IPasswordHasher<IdentityUser> passwordHasher) : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return passwordHasher.HashPassword(null, password);
            //return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
            //return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
