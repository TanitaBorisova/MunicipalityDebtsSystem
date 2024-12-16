using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;

namespace MunicipalityDebtsSystem.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IDebtService debtService;

        public AjaxController(IDebtService _debtService)
        {
            debtService = _debtService;
        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }


    }
}
