using PhoneManager.Domain.Models;
using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces.Services;

namespace PhoneManager.Domain.Services
{
    /// <summary>
    /// Базовый сервис для всех сервисов
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TModel">Модель</typeparam>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    public abstract class BaseService<TEntity, TModel, TId> : IBaseService<TModel, TId>
        where TEntity : BaseEntity<TId>
        where TModel : BaseModel<TId>
        where TId : IEquatable<TId>
    {
        public BaseService()
        {
            
        }

        /// <summary>
        /// Добавление и или обновление сущности в БД
        /// </summary>
        public abstract Task<TId> AddOrUpdateAsync(TModel model);

        /// <summary>
        /// Получить сущность по id
        /// </summary>
        /// <param name="id">Первичные ключ</param>
        public abstract Task<TModel> GetAsync(TId id);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public abstract Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public abstract Task RemoveAsync(TId id);
    }
}
