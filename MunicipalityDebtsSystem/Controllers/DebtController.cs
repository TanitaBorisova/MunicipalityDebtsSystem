using Microsoft.AspNetCore.Mvc;

namespace MunicipalityDebtsSystem.Controllers
{
    public class DebtController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
