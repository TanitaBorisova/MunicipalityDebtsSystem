using Microsoft.AspNetCore.Mvc;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    public class PeriodController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
