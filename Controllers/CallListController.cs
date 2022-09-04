using Microsoft.AspNetCore.Mvc;
using PhoneManager.Domain.Interfaces.Services;
using PhoneManager.Domain.Models;
using PhoneManager.Domain.Services;
using PhoneManager.Models;
using PhoneManager.Models.Interfaces.Services;
using PhoneManager.ViewModel.CallList;
using PhoneManager.ViewModel.ContactList;

namespace PhoneManager.Controllers
{
    /// <summary>
    /// Отображение списка вызова с фильтрами по контакту и периоду
    /// </summary>
    public class CallListController : BaseController
    {
        private readonly ICallService callService;

        public CallListController(AppDBContext appDBContext, ICallService callService) 
            : base(appDBContext)
        {
            this.callService = callService;
        }

        public async Task<IActionResult> Index(Filter filter)
        {
            return await CallList(filter);
        }

        /// <summary>
        /// Отображает список вызовов
        /// </summary>
        public async Task<IActionResult> CallList(Filter filter)
        {
            filter ??= new Filter();
            var calls = await callService.GetAllAsync();
            var filtredCalls = filter.CallerId.HasValue
                ? calls?.Where(i => filter.CallerId.HasValue && (i.Caller.Id == filter.CallerId.Value || i.Subscriber?.Id == filter.CallerId))
                : calls;
            filtredCalls = filter.CallStart.HasValue
                ? filtredCalls?.Where(i => i.CallStart >= filter.CallStart)
                : filtredCalls;
            filtredCalls = filter.CallEnd.HasValue
                ? filtredCalls?.Where(i => i.CallEnd <= filter.CallEnd)
                : filtredCalls;
            var model = new CallListViewModel().Init(filtredCalls.OrderBy(i => i.CallStart).ToList());

            return View(nameof(CallList), model);
        }

        /// <summary>
        /// Создание или редактирование контакта
        /// </summary>
        /// <param name="id">id контакта</param>
        [HttpGet]
        public async Task<IActionResult> CallEdit(string returnUrl, Guid? id = null)
        {
            var model = new CallEditViewModel();
            if (id.HasValue)
            {
                model.Init(await callService.GetAsync(id.Value));
            }
            model.ReturnUrl = string.IsNullOrWhiteSpace(returnUrl) ? Url.Action(nameof(CallList), "CallList") : returnUrl;
            return View(nameof(CallEdit), model);
        }

        [HttpPost]
        [ActionName(nameof(CallEdit))]
        public async Task<IActionResult> CallEditPost(CallEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var callModel = new CallModel()
            {
                Id = model.Id ?? Guid.Empty,
                Caller = new ContactModel() { Id = model.CallerId.Value },
                Subscriber = new ContactModel() { Id = model.SubscriberId.Value },
                CallStart = model.CallStart.Value,
                CallEnd = model.CallEnd.HasValue
                    ? model.CallEnd.Value
                    : DateTime.MaxValue,
            };

            await callService.AddOrUpdateAsync(callModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
