using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           
            string userId = User.Id();
            var model = await debtService.GetDebtByIdAsync(id);

            model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            model.DebtPartialInfo.MunicipalityName = model.MunicipalityName;
            model.DebtPartialInfo.MunicipalityCode = model.MunicipalityCode;
            model.DebtPartialInfo.CurrencyName = model.CurrencyName;
            model.DebtPartialInfo.DebtNumber = model.DebtNumber;
            model.DebtPartialInfo.BookDate = model.DateBook;

            return View(model);
        }

    }

}
