using PhoneManager.Domain.Interfaces;
using PhoneManager.Models.Entities;

namespace PhoneManager.Models.Interfaces
{
    public interface ICallRepository : IBaseRepository<Call, Guid>
    {

    }
}
