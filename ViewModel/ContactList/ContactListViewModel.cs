using PhoneManager.Models.Entities;

namespace PhoneManager.ViewModel.ContactList
{
    /// <summary>
    /// Модель списка контактов
    /// </summary>
    public class ContactListViewModel
    {
        public List<ContactItem> Items { get; set; }

        public ContactListViewModel Init(List<Contact> contacts)
        {
            Items = contacts?.Select(i => new ContactItem().Init(i)).ToList();

            return this;
        }
    }

    /// <summary>
    /// Модель контакта
    /// </summary>
    public class ContactItem
    {
        public Guid Id  { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        public ContactItem Init(Contact contact)
        {
            Id = contact.Id;
            PhoneNumber = contact.PhoneNumber.Number;
            FIO = contact.FIO;
            Address = contact.Address;

            return this;
        }
    }
}
