using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
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


        public IActionResult Index()
        {
            return View();
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

            DateTime dateBook;
            string strDateBook = model.DateBook.ToString(ValidationConstants.DateFormat);
            bool isDateBookValid = DateTime.TryParseExact(strDateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isDateBookValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }
            DateTime dateContractFinish;
            string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            DateTime dateRealContractFinish;
            string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
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
           
            
            await debtService.AddAsync(model, User.Id(), municipalityId);  //userId
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
                DebtParentId = entity.DebtParentId,
                DebtNumber = entity.DebtNumber,
                ResolutionNumber = entity.ResolutionNumber,
                DateBook = entity.DateBook,   //entity.DateBook.ToString(ValidationConstants.DateFormat),
                //DateNegotiate = model.DateBook,
                DateContractFinish = entity.DateContractFinish,
                DateRealFinish = entity.DateRealFinish,
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
            string strDateBook = model.DateBook.ToString(ValidationConstants.DateFormat);
            bool isDateBookValid = DateTime.TryParseExact(strDateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isDateBookValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }
            DateTime dateContractFinish;
            string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            DateTime dateRealContractFinish;
            string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
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

           

            await debtService.EditAsync(model, userId, municipalityId);
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
                Id = modelDebt.DebtId,
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
        public async Task<IActionResult> Negotiate(NegotiateDebtViewModel model)
        {

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
            string strDateBook = model.DateBook.ToString(ValidationConstants.DateFormat);
            bool isDateBookValid = DateTime.TryParseExact(strDateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook);
            if (!isDateBookValid)
            {
                ModelState.AddModelError(nameof(model.DateBook), ValidationConstants.InvalidDateErrorMessage);
            }
            DateTime dateContractFinish;
            string strDateContractFinish = model.DateContractFinish.ToString(ValidationConstants.DateFormat);
            bool isDateContractFinishValid = DateTime.TryParseExact(strDateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
            }

            DateTime dateRealContractFinish;
            string strDateRealContractFinish = model.DateRealFinish.ToString(ValidationConstants.DateFormat);
            bool isDateRealContractFinishValid = DateTime.TryParseExact(strDateRealContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRealContractFinish);
            if (!isDateContractFinishValid)
            {
                ModelState.AddModelError(nameof(model.DateContractFinish), ValidationConstants.InvalidDateErrorMessage);
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


            await debtService.NegotiateAsync(model, User.Id(), municipalityId);  //userId
            return RedirectToAction(nameof(Index));




        }
    }
}
