using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;
namespace MunicipalityDebtsSystem.Controllers
{
    public class DrawController : BaseController
    {
        private readonly IDrawService drawService;

        public DrawController(IDrawService _drawService)
        {
            drawService = _drawService;   
        }

        [HttpGet]
        public async Task<IActionResult> AddPlanned()
        {
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddPlannedDrawViewModel model = new AddPlannedDrawViewModel();

            //model.Currencies = await debtService.GetAllCurrenciesAsync();
            //model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            //model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            //model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            //model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            //model.InterestTypes = await debtService.GetAllInterestTypesAsync();
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddPlanned(AddPlannedDrawViewModel model, int id)
        {
            model.DebtId = id;
            string userId = User.Id();
            //To DO - to get it fro user profile
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            //bool currencyExists = await debtService.CheckCurrencyExistAsync(model.CurrencyId);
           

            //if (!currencyExists)
            //{
            //    ModelState.AddModelError(nameof(model.CurrencyId), ValidationConstants.CurrencyNotExist);
            //}

            


            //DateTime dateContractFinish;
            //string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            //bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            DateTime datePlannedDraw;

            bool isDatePlannedDrawValid = DateTime.TryParseExact(model.DrawDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePlannedDraw);
            if (!isDatePlannedDrawValid)
            {
                ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.InvalidDateErrorMessage);
            }

            //DateTime dateRealContractFinish;
            //string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            //bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateRealContractFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            model.OperationTypeId = (int)OperationType.PlannedDraw;

            if (model.OperationTypeId !=(int) OperationType.PlannedDraw)
            {
                ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            }


            if (!ModelState.IsValid)
            {
                //model.Currencies = await debtService.GetAllCurrenciesAsync();
                //model.CreditTypes = await debtService.GetAllCreditTypesAsync();
                //model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
                //model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
                //model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
                //model.InterestTypes = await debtService.GetAllInterestTypesAsync();
                model.MunicipalityName = municipalityName;
                model.MunicipalityCode = municipalityCode;
                return View(model);
            }

            //model.Currencies = await debtService.GetAllCurrenciesAsync();
            //model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            //model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            //model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            //model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            //model.InterestTypes = await debtService.GetAllInterestTypesAsync();


            await drawService.AddPlannedAsync(model, userId, municipalityId, datePlannedDraw);  //userId
            return RedirectToAction(nameof(Index));




        }
    }
}
