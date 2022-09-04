using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace PhoneManager.Models.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await context.Contacts.AsQueryable().Include(i => i.PhoneNumber).ToListAsync();
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            return await context.Contacts.AsQueryable().Include(i => i.PhoneNumber).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Contact entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(Contact entity)
        {
            await context.Set<Contact>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Contact entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
