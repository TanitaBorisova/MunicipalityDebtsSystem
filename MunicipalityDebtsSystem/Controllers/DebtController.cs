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
           
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> GetDebtsForDataTable() 
        {
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            var data = await debtService.GetAllDebtAsync(municipalityId);
            

            return Json(new { data = data });

        }





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
            if (!isDateRealContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            if (isAddedDateValid && isDateContractFinishValid && dateBook >= dateContractFinish)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.DateContractFinishAfterDateBook);
            }

            if (isAddedDateValid && isDateRealContractFinishValid && dateBook >= dateRealContractFinish)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.DateRealFinishAfterDateBook);
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

          
            
            await debtService.AddAsync(model, User.Id(), municipalityId, dateBook, dateContractFinish, dateRealContractFinish);  //userId
            return RedirectToAction(nameof(Index));

            

      
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            var entity = await debtService.GetEntityDebtById(id);

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

           
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
                DateBook = entity.DateBook.ToString(ValidationConstants.DateFormat),   
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

            if (isAddedDateValid && isDateContractFinishValid && dateBook >= dateContractFinish)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.DateContractFinishAfterDateBook);
            }

            if (isAddedDateValid && isDateRealContractFinishValid && dateBook >= dateRealContractFinish)
            {
                ModelState.AddModelError(nameof(model.DateRealFinish), ValidationConstants.DateRealFinishAfterDateBook);
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
           
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            string userId = User.Id();
            var model = await debtService.GetDebtByIdAsync(id);
            model.IsForFinish = await debtService.IsForFinish(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

           
            var userId = User.Id();
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
           
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");


            NegotiateDebtViewModel model = new NegotiateDebtViewModel();
            var entityParent = await debtService.GetEntityDebtById(id);

            if (entityParent == null || entityParent.IsDeleted)
            {
                return BadRequest();
            }
           
            if (entityParent.MunicipalityId != municipalityId)
            {
                return Unauthorized();
            }

            
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
               
                model.CreditTypeId = entityParent.CreditTypeId;
                model.CreditorTypeId = entityParent.CreditorTypeId;
                return View(model);
            }


            await debtService.NegotiateAsync(model, User.Id(), municipalityId, dateBook, dateContractFinish, dateRealContractFinish); 
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Finish(int id)
        {
            await debtService.SetDebtAsFinished(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
