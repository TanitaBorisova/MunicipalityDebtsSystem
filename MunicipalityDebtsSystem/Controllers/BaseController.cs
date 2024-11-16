using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MunicipalityDebtsSystem.Controllers
{
    //[Authorize]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            //TO DO ADD Method for UserId
            return View();
        }
    }
}
