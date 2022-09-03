using PhoneManager.Models.Interfaces;

namespace PhoneManager.Models.Repositories
{
    public class ConferenceRepository : BaseRepository, IConferenceRepository
    {
        public ConferenceRepository(AppDBContext context) : base(context)
        {
        }
    }
}
