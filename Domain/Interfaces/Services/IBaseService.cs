using PhoneManager.Domain.Models;
using System.Security.Cryptography;

namespace PhoneManager.Models.Interfaces.Services
{
    /// <summary>
    /// Базовый интерфейс для всех сервисов
    /// </summary>
    /// <typeparam name="TModel">Модель</typeparam>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    public interface IBaseService<TModel, TId>
        where TModel : BaseModel<TId>
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Обновление и добавление сущности в БД
        /// </summary>
        Task<TId> AddOrUpdateAsync(TModel model);
    }
}
