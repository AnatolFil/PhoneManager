using Microsoft.EntityFrameworkCore;
using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class PhoneNumberRepository : BaseRepository, IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<List<PhoneNumber>> GetAllAsync()
        {
            return await context.PhoneNumbers.ToListAsync();
        }

        public async Task<PhoneNumber> GetAsync(Guid id)
        {
            return await context.PhoneNumbers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(PhoneNumber entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(PhoneNumber entity)
        {
            await context.Set<PhoneNumber>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
