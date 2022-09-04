using PhoneManager.Domain.Models;
using PhoneManager.Models.Interfaces.Services;

namespace PhoneManager.Domain.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для работы с вызовами
    /// </summary>
    public interface ICallService : IBaseService<CallModel, Guid>
    {
    }
}
