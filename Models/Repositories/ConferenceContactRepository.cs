using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class ConferenceContactRepository : BaseRepository, IConferenceContactRepository
    {
        public ConferenceContactRepository(AppDBContext context) : base(context)
        {
        }
    }
}
