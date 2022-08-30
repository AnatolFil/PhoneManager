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
            var contacts = await contactRepository.GetAllAsync();

            return View(nameof(Index), new ContactListViewModel().Init(contacts));
        }
    }
}
