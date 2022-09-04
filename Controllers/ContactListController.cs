using Microsoft.AspNetCore.Mvc;
using PhoneManager.Domain.Models;
using PhoneManager.Models;
using PhoneManager.Models.Interfaces;
using PhoneManager.Models.Interfaces.Services;
using PhoneManager.ViewModel.ContactList;

namespace PhoneManager.Controllers
{
    /// <summary>
    /// Отображение списка контактов.
    /// Создание редактирование контакта.
    /// </summary>
    public class ContactListController : BaseController
    {
        private readonly IContactService contactService;

        public ContactListController(AppDBContext appDBContext,
            IContactService contactService) : base(appDBContext)
        {
            this.contactService = contactService;
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
            var contacts = await contactService.GetAllAsync();

            return View(nameof(ContactList), new ContactListViewModel().Init(contacts?.ToList()));
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
                model.Init(await contactService.GetAsync(id.Value));
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

            var contactModel = new ContactModel()
            {
                Id = model.Id.HasValue ? model.Id.Value : Guid.Empty,
                Address = model.Address,
                FIO = model.FIO,
                PhoneNumber = new PhoneNumberModel()
                {
                    Number = model.PhoneNumber
                }
            };

            await contactService.AddOrUpdateAsync(contactModel);

            return RedirectToAction(nameof(Index));
        }
        
        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">id контакта</param>
        public async Task<IActionResult> Remove(Guid id)
        {
            await contactService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
