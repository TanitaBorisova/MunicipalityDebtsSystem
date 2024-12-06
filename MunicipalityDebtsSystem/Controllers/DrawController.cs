using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Data.Migrations;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
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
        
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;

            //only for test added
            var data = await drawService.GetAllPlannedDrawsAsync();

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

        [HttpGet]
        public async Task<IActionResult> AddReal(int id)
        {
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddDrawViewModel model = new AddDrawViewModel();

            model.PlannedDrawDates = await drawService.GetAllPlannedDrawDatesAsync(id);
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddReal(AddDrawViewModel model, int id)
        {
            model.DebtId = id;
            string userId = User.Id();
            //To DO - to get it fro user profile
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;
            //model.DebtParentId = model.DrawParentId;
           
            //bool currencyExists = await debtService.CheckCurrencyExistAsync(model.CurrencyId);


            //if (!currencyExists)
            //{
            //    ModelState.AddModelError(nameof(model.CurrencyId), ValidationConstants.CurrencyNotExist);
            //}





            DateTime dateDraw;

            bool isDateDrawValid = DateTime.TryParseExact(model.DrawDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDraw);
            if (!isDateDrawValid)
            {
                ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.InvalidDateErrorMessage);
            }


            model.OperationTypeId = (int)OperationType.Draw;

            if (model.OperationTypeId != (int)OperationType.Draw)
            {
                ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            }


            if (!ModelState.IsValid)
            {
             
                model.PlannedDrawDates = await drawService.GetAllPlannedDrawDatesAsync(id);
                model.MunicipalityName = municipalityName;
                model.MunicipalityCode = municipalityCode;
                return View(model);
            }

        
            int drawParentId = Convert.ToInt32(TempData["PlannedDrawId"]);
            await drawService.AddRealAsync(model, userId, municipalityId, dateDraw, drawParentId);  //userId
            return RedirectToAction(nameof(Index));




        }

        [HttpGet]
        public async Task<JsonResult> GetPlannedDrawInfo(int plannedDrawId)
        {
            TempData["PlannedDrawId"] = plannedDrawId;  
            var plannedDrawInfo = await drawService.GetPlannedDrawInfoByIdAsync(plannedDrawId);
                return Json(plannedDrawInfo);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPlannedDrawsForDataTable() //int id
        //{
        //    var data = await drawService.GetAllPlannedDrawsAsync(); //id
        //    return Json(new { data = data }); 

        //}

        [HttpGet]
        public async Task<IActionResult> GetPlannedDrawsForDataTable()
        {
            //int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            var data = await drawService.GetAllPlannedDrawsAsync();  //id
            return Json(new { data = data });

        }


    }
}
