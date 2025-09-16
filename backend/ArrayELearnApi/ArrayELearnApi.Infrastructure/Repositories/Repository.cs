using ArrayELearnApi.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class Repository<TEntity>(DbContext context) : IRepository<TEntity> where TEntity : class
    {
        // You can still define fields/properties if needed
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
        
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public Task<int> SaveChangesTask() => context.SaveChangesAsync();

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public Task<TEntity?> GetByIdTask(int id) => _dbSet.FindAsync(id).AsTask();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public Task<List<TEntity>> GetAllTask() => _dbSet.ToListAsync();
        
        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        // Other repository methods would go here...
    }
}
