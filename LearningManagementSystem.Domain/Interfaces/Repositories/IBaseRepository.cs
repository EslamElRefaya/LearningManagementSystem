namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
