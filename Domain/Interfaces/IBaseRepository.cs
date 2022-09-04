using PhoneManager.Models.Entities;

namespace PhoneManager.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TId : IEquatable<TId>
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Guid id);

        Task UpdateAsync(TEntity entity);

        Task AddAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);
    }
}
