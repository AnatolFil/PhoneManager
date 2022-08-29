using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(AppDBContext context) : base(context)
        {
        }
    }
}
