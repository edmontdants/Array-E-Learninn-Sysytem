using ArrayELearnApi.Domain.Interfaces;
using ArrayELearnApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // This class would typically implement methods for data access, such as Add, GetAll, Update, Delete, etc.
        // For simplicity, we are leaving it empty here.
        // In a real application, you would use an ORM like Entity Framework or Dapper to interact with the database.
        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        
        public void DeleteAsync(TEntity entity) => _dbSet.Remove(entity);

        public void UpdateAsync(TEntity entity) => _dbSet.Update(entity);

        // Other repository methods would go here...
    }
}
