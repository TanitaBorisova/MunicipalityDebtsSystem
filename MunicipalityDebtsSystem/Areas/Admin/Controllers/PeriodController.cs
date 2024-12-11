using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.PeriodList;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    public class PeriodController : AdminBaseController
    {
        private readonly IMunicipalityService municipalityService;
        private readonly ICommonService commonService;
        private readonly IPeriodService periodService;

        public PeriodController(
            IMunicipalityService _municipalityService,
            ICommonService _commonService,
            IPeriodService _periodService
            )
        {
            municipalityService = _municipalityService;
            commonService = _commonService;
            periodService = _periodService; 
        }

        public async Task<IActionResult> Index()
        {
            PeriodListViewModel model = new PeriodListViewModel();    
            model.Municipalities = await municipalityService.GetAllMunicipalitiesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddPeriod()
        {
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddPeriodViewModel model = new AddPeriodViewModel();

            model.Municipalities = await municipalityService.GetAllMunicipalitiesAsync();
            model.Months = commonService.GetMonths();
            model.Years = commonService.GetYears();



            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> AddPeriod(AddPeriodViewModel model)
        {

            int municipalityId = model.MunicipalityId;

            model.Municipalities = await municipalityService.GetAllMunicipalitiesAsync();
            model.Months = commonService.GetMonths();
            model.Years = commonService.GetYears();

            DateTime periodStart;
            DateTime periodEnd;

            (periodStart, periodEnd) = BuildPeriod(model.MonthInt, model.YearInt);
            model.PeriodStart = periodStart;
            model.PeriodEnd = periodEnd;

            Month month = (Month)model.MonthInt;
            string monthName = month.ToString();

            model.MonthName = monthName;
            model.YearName = model.YearInt.ToString();

            if (!ModelState.IsValid)
            {
                model.Municipalities = await municipalityService.GetAllMunicipalitiesAsync();
                model.Months = commonService.GetMonths();
                model.Years = commonService.GetYears();
                return View(model);
            }

            PeriodList period = new PeriodList
            {
                MunicipalityId = model.MunicipalityId,
                MonthInt = model.MonthInt,
                YearInt = model.YearInt,
                PeriodStart = periodStart,
                PeriodEnd = periodEnd,
                MonthName = model.MonthName,
                YearName = model.YearName,
                UserNameUnlock = User.Identity.Name,
                DateUnlock = DateTime.Now,
                IsUnlock = true

            };
            bool IsPeriodExists = await periodService.IsPeriodExistsAndIsUnlock(model.MunicipalityId, model.MonthInt, model.YearInt);
            if (!IsPeriodExists)
            {
                await periodService.AddAsync(period);
            }

            
            return RedirectToAction(nameof(Index));




            ////bool monthExists = commonService.CheckMonthExist(model.MonthInt);
            ////bool yearExists = commonService.CheckYearExist(model.YearInt);


            ////if (!monthExists)
            ////{
            ////    ModelState.AddModelError(nameof(model.MonthInt), ValidationConstants.MonthNotExist);
            ////}

            ////if (!yearExists)
            ////{
            ////    ModelState.AddModelError(nameof(model.YearInt), ValidationConstants.YearNotExist);
            ////}



            ////DateTime dateBook;
            ////string strDateBook = model.DateBook.ToString(ValidationConstants.DateFormat);
            ////bool isDateBookValid = DateTime.TryParseExact(strDateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            ////if (!isDateBookValid)
            ////{
            ////    ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            ////}

            //DateTime dateBook;

            //bool isAddedDateValid = DateTime.TryParseExact(model.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            //if (!isAddedDateValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            //}

            ////DateTime dateContractFinish;
            ////string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            ////bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            ////if (!isDateContractFinishValid)
            ////{
            ////    ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            ////}

            //DateTime dateContractFinish;

            //bool isDateContractFinishValid = DateTime.TryParseExact(model.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            ////DateTime dateRealContractFinish;
            ////string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            ////bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            ////if (!isDateContractFinishValid)
            ////{
            ////    ModelState.AddModelError(nameof(model.DateRealContractFinish), ValidationConstants.InvalidDateErrorMessage);
            ////}

            //DateTime dateRealContractFinish;

            //bool isDateRealContractFinishValid = DateTime.TryParseExact(model.DateRealFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            //if (!ModelState.IsValid)
            //{
            //    model.Currencies = await debtService.GetAllCurrenciesAsync();
            //    model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            //    model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            //    model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            //    model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            //    model.InterestTypes = await debtService.GetAllInterestTypesAsync();
            //    model.MunicipalityName = municipalityName;
            //    model.MunicipalityCode = municipalityCode;
            //    return View(model);
            //}



            //await debtService.AddAsync(model, User.Id(), municipalityId, dateBook, dateContractFinish, dateRealContractFinish);  //userId
            //return RedirectToAction(nameof(Index));




        }

        private (DateTime StartDate, DateTime EndDate) BuildPeriod(int month, int year)
        { 
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);


            return (startDate, endDate); 
        }

        [HttpGet]
        public async Task<IActionResult> GetUnlockedPeriodsForDataTable(int id)
        {
            int municipalityId = id;
            var data = await this.periodService.GetPeriodsByMun(municipalityId);
            return Json(new { data = data });

        }
    }
}
