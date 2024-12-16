using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Cover;
using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.Globalization;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;


namespace MunicipalityDebtsSystem.Controllers
{
    public class CoverController : BaseController
    {

        private readonly ICoverService coverService;
        private readonly IDebtService debtService;

        public CoverController 
            (
                ICoverService _coverService,
                IDebtService _debtService
            )
        {
            coverService = _coverService;
            debtService = _debtService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCover(int id)
        {
            var debt = await debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                throw new ArgumentNullException("The debt does not exist");
            }

            string municipalityName = (User.FindFirstValue(UserMunicipalityNameClaim) ?? "");
            string municipalityCode = (User.FindFirstValue(UserMunicipalityCodeClaim) ?? "");

            AddCoverViewModel model = new AddCoverViewModel();

            model.DebtId = id;
            model.DebtPartialInfo = await debtService.FillDebtInfo(model.DebtPartialInfo, id, municipalityName, municipalityCode, debt.CurrencyName, debt.DebtNumber, debt.DateBook);
            model.CoverTypes = await coverService.GetAllCoversAsync();
            model.IsFinished = debt.IsFinished;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddCover(AddCoverViewModel model, int id)
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
            model.IsFinished = debt.IsFinished;

            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            await coverService.AddCoverAsync(model, userId, municipalityId);
            return RedirectToAction("AddCover", "Cover", new { id = model.DebtId });

            }

        [HttpGet]
        public async Task<IActionResult> GetCoversForDataTable(int id)
        {

            var data = await coverService.GetAllCoversAsync(id);
            return Json(new { data = data });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteCover(int id)
        {
            try
            {

                var cover = await coverService.GetCoverEntityByIdAsync(id);

                if (cover == null)
                {
                    return Json(new { success = false, message = "Записът не съществува." });
                }



                await coverService.RemoveCover(id);


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
