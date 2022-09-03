using PhoneManager.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Domain.Models
{
    /// <summary>
    /// Модель контакта
    /// </summary>
    public class ContactModel: BaseModel<Guid>
    {
        public ContactModel() : base() { }

        public ContactModel(Guid id) : this() { Id = id; }

        public PhoneNumberModel PhoneNumber { get; set; }

        public string FIO { get; set; }

        public string Address { get; set; }
    }
}
