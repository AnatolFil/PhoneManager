using PhoneManager.Models.Entities;
using System.Net;

namespace PhoneManager.Models.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();

        Task<Contact> GetAsync(Guid id);
    }
}
