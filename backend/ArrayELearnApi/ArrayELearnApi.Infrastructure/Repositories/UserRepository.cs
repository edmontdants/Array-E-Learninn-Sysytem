using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context) {
            _context= context;
        }

        public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default) => _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        public Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken = default) => _context.Users.AnyAsync(u => u.UserName == userName, cancellationToken);
    }
}
