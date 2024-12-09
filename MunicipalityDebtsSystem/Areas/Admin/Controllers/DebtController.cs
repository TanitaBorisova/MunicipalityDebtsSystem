using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    public class DebtController : AdminBaseController
    {

        private readonly IDebtService debtService;

        public DebtController(IDebtService _debtService)
        {
            debtService = _debtService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetDebtsAdminForDataTable()
        {
           
            var data = await this.debtService.GetAllDebtAdminAsync();
            return Json(new { data = data });

        }

        [HttpGet]
        public async Task<IActionResult> GetDebtsForDataTable()
        {
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            var data = await this.debtService.GetAllDebtAsync(municipalityId);
            return Json(new { data = data });

        }

    }

}
