using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;

namespace MunicipalityDebtsSystem.Controllers
{
    public class DebtController : BaseController
    {
        private readonly IDebtService debtService;

        public DebtController(IDebtService _debtService)
        {
            debtService = _debtService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           //var result = await debtService.GetDebtsWithPagingAsync(0, 10, "");
           // var debts = result.Debts;
           // return Json(debts); 

            return View();
        }
        //public class DataTableRequest
        //{
        //    public int draw { get; set; }
        //    public int start { get; set; }
        //    public int length { get; set; }
        //    public string searchValue { get; set; } = string.Empty;
        //}


        //public async Task<IActionResult> GetDebtsForDataTable(
        //[FromQuery] int draw,
        //[FromQuery] int start,
        //[FromQuery] int length,
        //[FromQuery] string searchValue)

        [HttpGet]
        public async Task<IActionResult> GetDebtsForDataTable() 
        {
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            var data = await this.debtService.GetAllDebtAsync(municipalityId);
            return Json(new { data = data });

        }



        //int draw,
        //int start,
        //int length,
        //string searchValue)
        //[FromQuery] int draw,
        //[FromQuery] int start,
        //[FromQuery] int length,
        //[FromQuery] string searchValue)

        //[HttpPost]
        //[Route("Debt/GetDebtsForDataTable")]
        //public async Task<IActionResult> GetDebtsForDataTable([FromBody] DataTableRequest request)

        //{
        //    try
        //    {
        //        //var result = await debtService.GetDebtsWithPagingAsync(start / length, length, searchValue);
        //        int start = request.start;
        //        int length = request.length;
        //        string searchValue = request.searchValue;
        //        int draw = 1;

        //        int first = start / length;
        //        var result = await debtService.GetDebtsWithPagingAsync(first, length, searchValue);

        //        var jsonResponse = new
        //        {
        //            draw = draw,
        //            recordsTotal = result.TotalRecords,
        //            recordsFiltered = result.FilteredRecords,
        //            data = result.Debts
        //        };

        //        return Json(jsonResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("An error occurred while fetching the data.");
        //    }
        //}



        //[HttpPost]
        //public async Task<IActionResult> GetDebtsForDataTable(int draw, int start, int length, string searchValue)
        //{
        //    try
        //    {
        //        // Log incoming parameters
        //        //_logger.LogInformation($"Received request: draw={draw}, start={start}, length={length}, searchValue={searchValue}");

        //        var result = await debtService.GetDebtsWithPagingAsync(start / length, length, searchValue);

        //        var jsonResponse = new
        //        {
        //            draw = draw,
        //            recordsTotal = result.TotalRecords,
        //            recordsFiltered = result.FilteredRecords,
        //            data = result.Debts
        //        };

        //        return Json(jsonResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError($"Error: {ex.Message}");
        //        return BadRequest("An error occurred while fetching the data.");
        //    }
        //}



        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddDebtViewModel model = new AddDebtViewModel();
            
            model.Currencies = await debtService.GetAllCurrenciesAsync();
            model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            model.InterestTypes = await debtService.GetAllInterestTypesAsync();
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;  

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> GetRate(int id)
        {
            decimal rate = await debtService.GetRate(id);

            return Json(new { success = true, rate });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDebtViewModel model)
        {

            //string userId = GetUserId();
            //To DO - to get it fro user profile
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            bool currencyExists = await debtService.CheckCurrencyExistAsync(model.CurrencyId);
            bool creditTypeExists = await debtService.CheckCreditTypeExistAsync(model.CreditTypeId);
            bool creditorTypeExists = await debtService.CheckCreditorTypeExistAsync(model.CreditorTypeId);
            bool debtTermTypeExists = await debtService.CheckCreditorTypeExistAsync(model.DebtTermTypeId);
            bool debtPurposeTypeExists = await debtService.CheckDebtPurposeTypeExistAsync(model.DebtPurposeTypeId);
            bool interestTypeExists = await debtService.CheckInterestTypeExistAsync(model.InterestTypeId);


            if (!currencyExists)
            {
                ModelState.AddModelError(nameof(model.CurrencyId), ValidationConstants.CurrencyNotExist);
            }

            if (!creditTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditTypeId), ValidationConstants.CreditTypeNotExist);
            }

            if (!creditorTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditorTypeId), ValidationConstants.CreditorTypeNotExist);
            }

            if (!debtTermTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtTermTypeId), ValidationConstants.DebtTermTypeNotExist);
            }

            if (!debtPurposeTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtPurposeTypeId), ValidationConstants.DebtPurposeTypeNotExist);
            }

            if (!interestTypeExists)
            {
                ModelState.AddModelError(nameof(model.InterestTypeId), ValidationConstants.InterestTypeNotExist);
            }

            //DateTime dateBook;
            //string strDateBook = model.DateBook.ToString(ValidationConstants.DateFormat);
            //bool isDateBookValid = DateTime.TryParseExact(strDateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            //if (!isDateBookValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            //}

            DateTime dateBook;

            bool isAddedDateValid = DateTime.TryParseExact(model.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isAddedDateValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }

            //DateTime dateContractFinish;
            //string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            //bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            DateTime dateContractFinish;

            bool isDateContractFinishValid = DateTime.TryParseExact(model.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            //DateTime dateRealContractFinish;
            //string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            //bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            //if (!isDateContractFinishValid)
            //{
            //    ModelState.AddModelError(nameof(model.DateRealContractFinish), ValidationConstants.InvalidDateErrorMessage);
            //}

            DateTime dateRealContractFinish;

            bool isDateRealContractFinishValid = DateTime.TryParseExact(model.DateRealFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateRealContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Currencies = await debtService.GetAllCurrenciesAsync();
                model.CreditTypes = await debtService.GetAllCreditTypesAsync();
                model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
                model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
                model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
                model.InterestTypes = await debtService.GetAllInterestTypesAsync();
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
           
            
            await debtService.AddAsync(model, User.Id(), municipalityId, dateBook, dateContractFinish, dateRealContractFinish);  //userId
            return RedirectToAction(nameof(Index));

            

      
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {//get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            var entity = await debtService.GetEntityDebtById(id);

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

            ////To DO
            if (entity.MunicipalityId != municipalityId)
            {
                return Unauthorized();
            }

            EditDebtViewModel model = new EditDebtViewModel
            {
                DebtId = entity.Id,
                DebtParentId = entity.DebtParentId  ?? 0,
                DebtNumber = entity.DebtNumber,
                ResolutionNumber = entity.ResolutionNumber,
                DateBook = entity.DateBook.ToString(ValidationConstants.DateFormat),   //entity.DateBook.ToString(ValidationConstants.DateFormat),
                //DateNegotiate = model.DateBook,
                DateContractFinish = entity.DateContractFinish.ToString(ValidationConstants.DateFormat),
                DateRealFinish = entity.DateRealFinish.ToString(ValidationConstants.DateFormat),
                CurrencyId = entity.CurrencyId,
                DebtAmountOriginalCcy = entity.DebtAmountOriginalCcy,
                DebtAmountLocalCcy = entity.DebtAmountLocalCcy,
                CreditTypeId = entity.CreditTypeId,
                CreditorTypeId = entity.CreditorTypeId,
                DebtTermTypeId = entity.DebtTermTypeId,
                DebtPurposeTypeId = entity.DebtPurposeTypeId,
                InterestRate = entity.InterestRate,
                InterestTypeId = entity.InterestTypeId,
                MunicipalityId = entity.MunicipalityId,
                MunicipalityName = municipalityName,
                MunicipalityCode = municipalityCode
            };

            model.Currencies = await debtService.GetAllCurrenciesAsync();
            model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            model.InterestTypes = await debtService.GetAllInterestTypesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDebtViewModel model, int id)
        {
            string userId = User.Id();
            ////To DO to get from the user
            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;

            bool currencyExists = await debtService.CheckCurrencyExistAsync(model.CurrencyId);
            bool creditTypeExists = await debtService.CheckCreditTypeExistAsync(model.CreditTypeId);
            bool creditorTypeExists = await debtService.CheckCreditorTypeExistAsync(model.CreditorTypeId);
            bool debtTermTypeExists = await debtService.CheckCreditorTypeExistAsync(model.DebtTermTypeId);
            bool debtPurposeTypeExists = await debtService.CheckDebtPurposeTypeExistAsync(model.DebtPurposeTypeId);
            bool interestTypeExists = await debtService.CheckInterestTypeExistAsync(model.InterestTypeId);


            if (!currencyExists)
            {
                ModelState.AddModelError(nameof(model.CurrencyId), ValidationConstants.CurrencyNotExist);
            }

            if (!creditTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditTypeId), ValidationConstants.CreditTypeNotExist);
            }

            if (!creditorTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditorTypeId), ValidationConstants.CreditorTypeNotExist);
            }

            if (!debtTermTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtTermTypeId), ValidationConstants.DebtTermTypeNotExist);
            }

            if (!debtPurposeTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtPurposeTypeId), ValidationConstants.DebtPurposeTypeNotExist);
            }

            if (!interestTypeExists)
            {
                ModelState.AddModelError(nameof(model.InterestTypeId), ValidationConstants.InterestTypeNotExist);
            }
            var entity = await debtService.GetEntityDebtById(id);

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }


            ////To DO
            if (entity.MunicipalityId != municipalityId)
            {
                return Unauthorized();
            }
                       
            DateTime dateBook;

            bool isAddedDateValid = DateTime.TryParseExact(model.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isAddedDateValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }


            DateTime dateContractFinish;

            bool isDateContractFinishValid = DateTime.TryParseExact(model.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            

            DateTime dateRealContractFinish;

            bool isDateRealContractFinishValid = DateTime.TryParseExact(model.DateRealFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Currencies = await debtService.GetAllCurrenciesAsync();
                model.CreditTypes = await debtService.GetAllCreditTypesAsync();
                model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
                model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
                model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
                model.InterestTypes = await debtService.GetAllInterestTypesAsync();
               
                model.MunicipalityName = municipalityName;
                model.MunicipalityCode = municipalityCode;
               
                return View(model);
            }

            model.Currencies = await debtService.GetAllCurrenciesAsync();
            model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            model.InterestTypes = await debtService.GetAllInterestTypesAsync();

           

            await debtService.EditAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealContractFinish);
            return RedirectToAction(nameof(Index));

     }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            string userId = GetUserId();
            var model = await debtService.GetDebtByIdAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //get municipality from user
            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            //da napiwa drug metod za vry6tane na danni
            var userId = GetUserId();
            var modelDebt = await debtService.GetDebtByIdAsync(id);
            if (modelDebt == null || modelDebt.MunicipalityId != municipalityId)
            {
                return RedirectToAction(nameof(Index));
            }

            DeleteDebtViewModel model = new DeleteDebtViewModel
            {
                Id = modelDebt.Id,
                DebtNumber = modelDebt.DebtNumber,
                DateBook = modelDebt.DateBook,
                DateContractFinish = modelDebt.DateContractFinish,
                CurrencyName = modelDebt.CurrencyName,
                DebtAmountOriginalCcy = modelDebt.DebtAmountOriginalCcy,
                DebtAmountLocalCcy = modelDebt.DebtAmountLocalCcy,

       

    };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteDebtViewModel model)
        {
            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            var userId = GetUserId();
            var entity = await debtService.GetEntityDebtById(id);
            if (entity == null || entity.MunicipalityId != municipalityId)
            {
                return RedirectToAction(nameof(Index));
            }
            await debtService.DeleteDebt(entity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Negotiate(int id)
        {
            //id e ParentId

            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");


            NegotiateDebtViewModel model = new NegotiateDebtViewModel();
            var entityParent = await debtService.GetEntityDebtById(id);

            if (entityParent == null || entityParent.IsDeleted)
            {
                return BadRequest();
            }
            ////To DO
            if (entityParent.MunicipalityId != municipalityId)
            {
                return Unauthorized();
            }

            //Set values from parent
            model.CreditTypeId = entityParent.CreditTypeId;
            model.CreditorTypeId = entityParent.CreditorTypeId;

            model.MunicipalityId = municipalityId;
            model.MunicipalityName = municipalityName;
            model.MunicipalityCode = municipalityCode;
           
            
            model.Currencies = await debtService.GetAllCurrenciesAsync();
            model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            model.InterestTypes = await debtService.GetAllInterestTypesAsync();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Negotiate(NegotiateDebtViewModel model, int id)
        {
            model.DebtParentId = id;

            string userId = User.Id();
         
            //get municipality from user
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            bool currencyExists = await debtService.CheckCurrencyExistAsync(model.CurrencyId);
            bool creditTypeExists = await debtService.CheckCreditTypeExistAsync(model.CreditTypeId);
            bool creditorTypeExists = await debtService.CheckCreditorTypeExistAsync(model.CreditorTypeId);
            bool debtTermTypeExists = await debtService.CheckCreditorTypeExistAsync(model.DebtTermTypeId);
            bool debtPurposeTypeExists = await debtService.CheckDebtPurposeTypeExistAsync(model.DebtPurposeTypeId);
            bool interestTypeExists = await debtService.CheckInterestTypeExistAsync(model.InterestTypeId);

            if (model.MunicipalityId != municipalityId)
            {
                return Unauthorized();
            }

            if (!currencyExists)
            {
                ModelState.AddModelError(nameof(model.CurrencyId), ValidationConstants.CurrencyNotExist);
            }

            if (!creditTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditTypeId), ValidationConstants.CreditTypeNotExist);
            }

            if (!creditorTypeExists)
            {
                ModelState.AddModelError(nameof(model.CreditorTypeId), ValidationConstants.CreditorTypeNotExist);
            }

            if (!debtTermTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtTermTypeId), ValidationConstants.DebtTermTypeNotExist);
            }

            if (!debtPurposeTypeExists)
            {
                ModelState.AddModelError(nameof(model.DebtPurposeTypeId), ValidationConstants.DebtPurposeTypeNotExist);
            }

            if (!interestTypeExists)
            {
                ModelState.AddModelError(nameof(model.InterestTypeId), ValidationConstants.InterestTypeNotExist);
            }

            
            DateTime dateBook;

            bool isAddedDateValid = DateTime.TryParseExact(model.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isAddedDateValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }


            DateTime dateContractFinish;

            bool isDateContractFinishValid = DateTime.TryParseExact(model.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }



            DateTime dateRealContractFinish;

            bool isDateRealContractFinishValid = DateTime.TryParseExact(model.DateRealFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            //model.UserCreated = userId;
            //model.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                model.Currencies = await debtService.GetAllCurrenciesAsync();
                model.CreditTypes = await debtService.GetAllCreditTypesAsync();
                model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
                model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
                model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
                model.InterestTypes = await debtService.GetAllInterestTypesAsync();
                model.MunicipalityName = municipalityName;
                model.MunicipalityCode = municipalityCode;

                var entityParent = await debtService.GetEntityDebtById(id);
                //Set values from parent
                model.CreditTypeId = entityParent.CreditTypeId;
                model.CreditorTypeId = entityParent.CreditorTypeId;
                return View(model);
            }

            //model.Currencies = await debtService.GetAllCurrenciesAsync();
            //model.CreditTypes = await debtService.GetAllCreditTypesAsync();
            //model.CreditorTypes = await debtService.GetAllCreditorTypesAsync();
            //model.DebtTermTypes = await debtService.GetAllDebtTermTypesAsync();
            //model.DebtPurposeTypes = await debtService.GetAllDebtPurposeTypesAsync();
            //model.InterestTypes = await debtService.GetAllInterestTypesAsync();


            await debtService.NegotiateAsync(model, User.Id(), municipalityId, dateBook, dateContractFinish, dateRealContractFinish);  //userId
            return RedirectToAction(nameof(Index));




        }
    }
}
