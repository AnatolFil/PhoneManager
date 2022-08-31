using Microsoft.AspNetCore.Mvc;
using PhoneManager.Models;
using PhoneManager.Models.Interfaces;
using PhoneManager.ViewModel.ContactList;

namespace PhoneManager.Controllers
{
    /// <summary>
    /// Отображение списка контактов
    /// </summary>
    public class ContactListController : BaseController
    {
        private readonly IContactRepository contactRepository;

        public ContactListController(AppDBContext appDBContext, IContactRepository contactRepository) : base(appDBContext)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<IActionResult> Index()
        { 
            return await ContactList();
        }

        /// <summary>
        /// Отображает список контактов
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ContactList()
        {
            var contacts = await contactRepository.GetAllAsync();

            return View(nameof(ContactList), new ContactListViewModel().Init(contacts));
        }
    }
}
