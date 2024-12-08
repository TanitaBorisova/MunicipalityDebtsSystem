using Microsoft.AspNetCore.Mvc;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
