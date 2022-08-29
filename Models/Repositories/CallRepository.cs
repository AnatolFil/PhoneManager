using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class CallRepository : BaseRepository, ICallRepository
    {
        public CallRepository(AppDBContext context) : base(context)
        {
        }
    }
}
