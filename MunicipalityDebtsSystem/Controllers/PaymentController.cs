﻿using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
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
                //reload partial
                //reload dataTable???
                return View(model);
            }

            await paymentService.AddPlannedPaymentAsync(model, userId, municipalityId, datePlannedPayment);  
            return RedirectToAction("AddPlannedPayment", "Payment", new { id = model.DebtId });

        }


        [HttpGet]
        public async Task<IActionResult> GetPlannedDrawsForDataTable(int id)
        {

            var data = await paymentService.GetAllPlannedPaymentsAsync(id);
            return Json(new { data = data });

        }
    }
}
