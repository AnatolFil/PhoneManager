using Microsoft.AspNetCore.Mvc;
using PhoneManager.Models;

namespace PhoneManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AppDBContext appDBContext;

        public BaseController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
    }
}
