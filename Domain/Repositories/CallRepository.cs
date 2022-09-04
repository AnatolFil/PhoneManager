using Microsoft.EntityFrameworkCore;
using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class CallRepository : BaseRepository, ICallRepository
    {
        public CallRepository(AppDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Call entity)
        {
            await context.Set<Call>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Call>> GetAllAsync()
        {
            return await context.Calls.AsQueryable()
                .Include(i => i.Caller)
                .Include(i => i.Caller.PhoneNumber)
                .Include(i => i.Subscriber)
                .Include(i => i.Subscriber.PhoneNumber)
                .ToListAsync();
        }

        public async Task<Call> GetAsync(Guid id)
        {
            return await context.Calls.AsQueryable().Include(i => i.Caller).Include(i => i.Subscriber).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task RemoveAsync(Call entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Call entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
