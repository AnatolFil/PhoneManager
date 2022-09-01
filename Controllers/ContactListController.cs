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
        public async Task<IActionResult> ContactList()
        {
            var contacts = await contactRepository.GetAllAsync();

            return View(nameof(ContactList), new ContactListViewModel().Init(contacts));
        }

        /// <summary>
        /// Создание или редактирование контакта
        /// </summary>
        /// <param name="id">id контакта</param>
        [HttpGet]
        public async Task<IActionResult> ContactEdit(string returnUrl, Guid? id = null)
        {
            var model = new ContactEditViewModel();
            if (id.HasValue)
            {
                model.Init(await contactRepository.GetAsync(id.Value));
            }
            model.ReturnUrl = string.IsNullOrWhiteSpace(returnUrl) ? Url.Action(nameof(ContactList), "ContactList") : returnUrl;
            return View(nameof(ContactEdit), model);
        }

        [HttpPost]
        [ActionName(nameof(ContactEdit))]
        public async Task<IActionResult> ContactEditPost(ContactEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
