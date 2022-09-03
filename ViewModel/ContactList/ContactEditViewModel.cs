using PhoneManager.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.ViewModel.ContactList
{
    /// <summary>
    /// Модель для редактирования или создания нового контакта
    /// </summary>
    public class ContactEditViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [RegularExpression(@"^[+]([0-9]{1})[-]([0-9]{3})[-]([0-9]{3})[-]([0-9]{2})[-]([0-9]{2})$", ErrorMessage = "Поле должно соответствовать шаблону +х-ххх-ххх-хх-хх")]
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(100, ErrorMessage = "Количество символов не должно превышать {1}")]
        [Display(Name = "Фамилия Имя Отчество")]
        public string FIO { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [StringLength(300, ErrorMessage = "Количество символов не должно превышать {1}")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        public string ReturnUrl { get; set; }

        public ContactEditViewModel Init(Contact contact = null)
        {
            if(contact != null)
            {
                Id = contact.Id;
                PhoneNumber = contact.PhoneNumber.Number;
                FIO = contact.FIO;
                Address = contact.Address;
            }
            return this;
        }
    }
}
