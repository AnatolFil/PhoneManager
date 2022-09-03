using PhoneManager.Domain.Models;
using System.Security.Cryptography;

namespace PhoneManager.Models.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для работы с контактами
    /// </summary>
    public interface IContactService: IBaseService<ContactModel, Guid>
    {
        
    }
}
