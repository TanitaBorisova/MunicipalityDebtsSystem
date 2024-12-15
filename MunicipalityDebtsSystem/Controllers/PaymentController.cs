using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;

namespace MunicipalityDebtsSystem.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService paymentService;
        private readonly IDebtService debtService;


        public PaymentController
        (
            IPaymentService _paymentService,
            IDebtService _debtService
        )
        {
            paymentService = _paymentService;
            debtService = _debtService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPlannedPayment(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddPlannedPaymentViewModel model = new AddPlannedPaymentViewModel();

            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);

            model.DebtId = id;
            model.IsFinished = debt.IsFinished;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddPlannedPayment(AddPlannedPaymentViewModel model, int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            model.DebtId = id;
            string userId = User.Id();
           
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            model.IsFinished = debt.IsFinished;
            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);

                       

            DateTime datePlannedPayment;

            bool isDatePlannedPaymentValid = DateTime.TryParseExact(model.PaymentDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePlannedPayment);
            if (!isDatePlannedPaymentValid)
            {
                ModelState.AddModelError(nameof(model.PaymentDate), ValidationConstants.InvalidDateErrorMessage);
            }


            model.OperationTypeId = (int)OperationType.PlannedPayment;

            if (model.OperationTypeId != (int)OperationType.PlannedPayment)
            {
                ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            }


            if (!ModelState.IsValid)
            {
               
                return View(model);
            }

            await paymentService.AddPlannedPaymentAsync(model, userId, municipalityId, datePlannedPayment);  
            return RedirectToAction("AddPlannedPayment", "Payment", new { id = model.DebtId });

        }


        [HttpGet]
        public async Task<IActionResult> GetPlannedPaymentsForDataTable(int id)
        {

            var data = await paymentService.GetAllPlannedPaymentsAsync(id);
            return Json(new { data = data });

        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentsForDataTable(int id)
        {

            var data = await paymentService.GetAllPaymentsAsync(id);
            return Json(new { data = data });

        }


        [HttpPost]
        public async Task<IActionResult> DeletePlannedPayment(int id)
        {
            try
            {

                var payment = await paymentService.GetPaymentEntityByIdAsync(id);

                if (payment == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }


                bool hasChildDraws = await paymentService.PlannedPaymentHasChildsAsync(id);

                if (hasChildDraws)
                {
                    return Json(new { success = false, message = "Планираното плащане не може да бъде изтрито. Към него има записани едно или повече реални плащания." });
                }



                await paymentService.RemovePayment(id);


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {

                var payment = await paymentService.GetPaymentEntityByIdAsync(id);

                if (payment == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }



                await paymentService.RemovePayment(id);


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddPayment(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);

            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddPaymentViewModel model = new AddPaymentViewModel();

            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);

            model.DebtId = id;
            model.IsFinished = debt.IsFinished;
            model.PlannedPaymentDates = await paymentService.GetAllPlannedPaymentDatesAsync(id);
           
           
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(AddPaymentViewModel model, int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            model.DebtId = id;
            string userId = User.Id();

            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");
            model.IsFinished = debt.IsFinished;
            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            ////model.DebtParentId = model.DrawParentId;

            DateTime datePayment;

            bool isDatePaymentValid = DateTime.TryParseExact(model.PaymentDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePayment);
            if (!isDatePaymentValid)
            {
                ModelState.AddModelError(nameof(model.PaymentDate), ValidationConstants.InvalidDateErrorMessage);
            }


            model.OperationTypeId = (int)OperationType.Payment;

            if (model.OperationTypeId != (int)OperationType.Payment)
            {
                ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            }


            if (!ModelState.IsValid)
            {

                model.PlannedPaymentDates = await paymentService.GetAllPlannedPaymentDatesAsync(id);

                return View(model);
            }


            int paymentParentId = Convert.ToInt32(TempData["PlannedPaymentId"]);
            await paymentService.AddRealAsync(model, userId, municipalityId, datePayment, paymentParentId);  
            return RedirectToAction(nameof(AddPayment));


        }

        [HttpGet]
        public async Task<JsonResult> GetPlannedPaymentInfo(int plannedPaymentId)
        {
            TempData["PlannedPaymentId"] = plannedPaymentId;
            var plannedPaymentInfo = await paymentService.GetPlannedPaymentInfoByIdAsync(plannedPaymentId);
            return Json(plannedPaymentInfo);
        }

    }
}
