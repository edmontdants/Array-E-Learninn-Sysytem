namespace ArrayELearnApi.Application.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // 1. Async versions with await
        Task<int> SaveChangesAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        // 2. Async versions without await (forwarding tasks)
        Task<int> SaveChangesTask();
        Task<TEntity?> GetByIdTask(int id);
        Task<List<TEntity>> GetAllTask();

        // 3. Sync versions
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
