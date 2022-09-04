using PhoneManager.Models.Entities;

namespace PhoneManager.Domain.Models
{
    public class PhoneNumberModel : BaseModel<Guid>
    {
        public PhoneNumberModel() : base() { }

        public PhoneNumberModel(Guid id) : this() { Id = id; }

        public string Number { get; set; }
    }
}
