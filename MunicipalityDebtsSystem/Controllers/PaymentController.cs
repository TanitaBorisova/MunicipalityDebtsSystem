using Microsoft.AspNetCore.Mvc;

namespace MunicipalityDebtsSystem.Controllers
{
    public class PaymentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
