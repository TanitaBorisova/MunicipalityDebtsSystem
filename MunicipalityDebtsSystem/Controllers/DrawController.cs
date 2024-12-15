using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;
namespace MunicipalityDebtsSystem.Controllers
{
    public class DrawController : BaseController
    {
        private readonly IDrawService drawService;
        private readonly IDebtService debtService;

        public DrawController(IDrawService _drawService, IDebtService _debtService)
        {
            drawService = _drawService;
            debtService = _debtService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPlanned(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddPlannedDrawViewModel model = new AddPlannedDrawViewModel();
            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            model.DebtId = id;
            //decimal sumPayments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            //model.DebtPartialInfo.Payments = sumPayments;
            //decimal sumPlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            //model.DebtPartialInfo.PlannedPayments = sumPlannedPayments;
            //decimal sumDraws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            //model.DebtPartialInfo.Draws = sumDraws;
            //decimal sumPlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);
            //model.DebtPartialInfo.PlannedDraws = sumPlannedDraws;

            //model.DebtPartialInfo.RealRemainDebt = sumDraws - sumPayments;
            //model.DebtPartialInfo.PlannedRemainDebt = sumPlannedDraws - sumPlannedPayments;

            //model.DebtPartialInfo.MunicipalityName = municipalityName;
            //model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            //model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            //model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            //model.DebtPartialInfo.BookDate = debt.DateBook;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddPlanned(AddPlannedDrawViewModel model, int id)
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


            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            //////////////////////////////////////////////////////////TO DO IN A METHOD
            
            //model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            //model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            //model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            //model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            //model.DebtPartialInfo.MunicipalityName = municipalityName;
            //model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            //model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            //model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            //model.DebtPartialInfo.BookDate = debt.DateBook;
            ///////////////////////////////////////////////////////////////////////////

            DateTime datePlannedDraw;

            bool isDatePlannedDrawValid = DateTime.TryParseExact(model.DrawDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePlannedDraw);
            if (!isDatePlannedDrawValid)
            {
                ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.InvalidDateErrorMessage);
            }


            model.OperationTypeId = (int)OperationType.PlannedDraw;

            if (model.OperationTypeId != (int)OperationType.PlannedDraw)
            {
                ModelState.AddModelError(nameof(model.OperationTypeId), ValidationConstants.OperationTypeIdErrorMessage);
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await drawService.AddPlannedAsync(model, userId, municipalityId, datePlannedDraw);  
            return RedirectToAction("AddPlanned", "Draw", new { id = model.DebtId });

        }

        [HttpGet]
        public async Task<IActionResult> AddReal(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");
           
            AddDrawViewModel model = new AddDrawViewModel();
            model.DebtId = id;
            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);

            //model.PlannedDrawDates = await drawService.GetAllPlannedDrawDatesAsync(id);
           
            ////////////////////////////////////////////////////////////TO DO IN A METHOD
            /////model.DebtId = id;
            //model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            //model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            //model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            //model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            //model.DebtPartialInfo.MunicipalityName = municipalityName;
            //model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            //model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            //model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            //model.DebtPartialInfo.BookDate = debt.DateBook;
            ///////////////////////////////////////////////////////////////////////////
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddReal(AddDrawViewModel model, int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            model.DebtId = id;
            string userId = User.Id();
           
            int municipalityId = Convert.ToInt32(User.FindFirstValue(UserMunicipalityIdClaim));
            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");


            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            

            ////////////////////////////////////////////////////////////TO DO IN A METHOD
            /////model.DebtId = id;
            //model.DebtPartialInfo.Payments = await debtService.ReturnSumOfOperationType((int)OperationType.Payment, id);
            //model.DebtPartialInfo.PlannedPayments = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedPayment, id);
            //model.DebtPartialInfo.Draws = await debtService.ReturnSumOfOperationType((int)OperationType.Draw, id);
            //model.DebtPartialInfo.PlannedDraws = await debtService.ReturnSumOfOperationType((int)OperationType.PlannedDraw, id);

            //model.DebtPartialInfo.MunicipalityName = municipalityName;
            //model.DebtPartialInfo.MunicipalityCode = municipalityCode;
            //model.DebtPartialInfo.CurrencyName = debt.CurrencyName;
            //model.DebtPartialInfo.DebtNumber = debt.DebtNumber;
            //model.DebtPartialInfo.BookDate = debt.DateBook;
            ///////////////////////////////////////////////////////////////////////////

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
               
                return View(model);
            }


            int drawParentId = Convert.ToInt32(TempData["PlannedDrawId"]);
            await drawService.AddRealAsync(model, userId, municipalityId, dateDraw, drawParentId);  //userId
            return RedirectToAction(nameof(AddReal));


        }

        [HttpGet]
        public async Task<JsonResult> GetPlannedDrawInfo(int plannedDrawId)
        {
            TempData["PlannedDrawId"] = plannedDrawId;
            var plannedDrawInfo = await drawService.GetPlannedDrawInfoByIdAsync(plannedDrawId);
            return Json(plannedDrawInfo);
        }


        [HttpGet]
        public async Task<IActionResult> GetPlannedDrawsForDataTable(int id)  
        {

            var data = await drawService.GetAllPlannedDrawsAsync(id); 
            return Json(new { data = data });

         }
        [HttpGet]
        public async Task<IActionResult> GetDrawsForDataTable(int id)
        {

            var data = await drawService.GetAllDrawsAsync(id);
            return Json(new { data = data });

        }


        [HttpPost] 
       // [ValidateAntiForgeryToken]  //there is global filter
        public async Task<IActionResult> DeletePlannedDraw(int id)
        {
            try
            {
                
                var draw = await drawService.GetDrawEntityByIdAsync(id);

                if (draw == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }

               
                bool hasChildDraws = await drawService.PlannedDrawHasChildsAsync(id);   

                if ( hasChildDraws)
                {
                    return Json(new { success = false, message = "Планираното плащане не може да бъде изтрито. Към него има записани едно или повече реални плащания." });
                }

               

                await drawService.RemoveDraw(id);
                

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
               
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDraw(int id)
        {
            try
            {

                var draw = await drawService.GetDrawEntityByIdAsync(id);

                if (draw == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }

                              

                await drawService.RemoveDraw(id);


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }

    }


    }

