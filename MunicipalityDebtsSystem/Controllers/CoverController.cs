using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Cover;
using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;


namespace MunicipalityDebtsSystem.Controllers
{
    public class CoverController : BaseController
    {

        private readonly ICoverService coverService;
        private readonly IDebtService debtService;

        public CoverController 
            (
                ICoverService _coverService,
                IDebtService _debtService
            )
        {
            coverService = _coverService;
            debtService = _debtService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCover(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddCoverViewModel model = new AddCoverViewModel();
            model.DebtId = id;
            model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            model.DebtPartialInfo.MunicipalityName = municipalityName;
            model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            model.DebtPartialInfo.BookDate = debt.DateBook;

            model.CoverTypes = await coverService.GetAllCoversAsync();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddCover(AddCoverViewModel model, int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            model.DebtId = id;
            string userId = User.Id();
            //To DO - to get it fro user profile
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            //////////////////////////////////////////////////////////TO DO IN A METHOD
            ///model.DebtId = id;
            model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            model.DebtPartialInfo.MunicipalityName = municipalityName;
            model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            model.DebtPartialInfo.BookDate = debt.DateBook;
            ///////////////////////////////////////////////////////////////////////////

            //DateTime datePlannedPayment;

            //bool isDatePlannedPaymentValid = DateTime.TryParseExact(model.PaymentDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePlannedPayment);
            //if (!isDatePlannedPaymentValid)
            //{
            //    ModelState.AddModelError(nameof(model.PaymentDate), ValidationConstants.InvalidDateErrorMessage);
            //}


            //model.CoverTypeId = (int)OperationType.PlannedPayment;

            //if (model.OperationTypeId != (int)OperationType.PlannedPayment)
            //{
            //    ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            //}


            if (!ModelState.IsValid)
            {
                //reload partial
                //reload dataTable???
                return View(model);
            }

            await coverService.AddCoverAsync(model, userId, municipalityId);
            return RedirectToAction("AddCover", "Cover", new { id = model.DebtId });

            }

        [HttpGet]
        public async Task<IActionResult> GetCoversForDataTable(int id)
        {

            var data = await coverService.GetAllCoversAsync(id);
            return Json(new { data = data });

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCover(int id)
        {
            try
            {

                var cover = await coverService.GetCoverEntityByIdAsync(id);

                if (cover == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }



                await coverService.RemoveCover(id);


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
