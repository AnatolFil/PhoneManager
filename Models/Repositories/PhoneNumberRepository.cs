using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class PhoneNumberRepository : BaseRepository, IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDBContext context) : base(context)
        {
        }
    }
}
