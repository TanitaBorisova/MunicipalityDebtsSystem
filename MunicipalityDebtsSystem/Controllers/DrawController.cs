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
            model.OperationTypeId = (int)OperationType.PlannedDraw;
            model.IsFinished = debt.IsFinished;

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
            model.IsFinished = debt.IsFinished;

            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
           
            DateTime datePlannedDraw;

            bool isDatePlannedDrawValid = DateTime.TryParseExact(model.DrawDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePlannedDraw);
            if (!isDatePlannedDrawValid)
            {
                ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.InvalidDateErrorMessage);
            }

            
            DateTime dateBook, dateContractFinish;
            if (DateTime.TryParseExact(debt.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook) &&
                DateTime.TryParseExact(debt.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish))
            {
                
                if (datePlannedDraw < dateBook || datePlannedDraw > dateContractFinish)
                {
                    ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.PlannedDrawValidationDate);
                }
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
            model.IsFinished = debt.IsFinished;
            model.PlannedDrawDates = await drawService.GetAllPlannedDrawDatesAsync(id);
           
           
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
            model.IsFinished = debt.IsFinished;

            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            
                        

            DateTime dateDraw;

            bool isDateDrawValid = DateTime.TryParseExact(model.DrawDate, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDraw);
            if (!isDateDrawValid)
            {
                ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.InvalidDateErrorMessage);
            }

            DateTime dateBook, dateContractFinish;
            if (DateTime.TryParseExact(debt.DateBook, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBook) &&
                DateTime.TryParseExact(debt.DateContractFinish, ValidationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateContractFinish))
            {

                if (dateDraw < dateBook || dateDraw > dateContractFinish)
                {
                    ModelState.AddModelError(nameof(model.DrawDate), ValidationConstants.DrawValidationDate);
                }
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

