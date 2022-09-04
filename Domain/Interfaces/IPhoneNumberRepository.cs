using PhoneManager.Models.Entities;

namespace PhoneManager.Models.Interfaces
{
    public interface IPhoneNumberRepository
    {
        Task<List<PhoneNumber>> GetAllAsync();

        Task<PhoneNumber> GetAsync(Guid id);

        Task UpdateAsync(PhoneNumber entity);

        Task AddAsync(PhoneNumber entity);
    }
}
