using Microsoft.AspNetCore.Mvc;
using MunicipalityDebtsSystem.Core.Models.Common;
using MunicipalityDebtsSystem.Core.Contracts;
using System.Security.Claims;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;
using MunicipalityDebtsSystem.Areas.Admin.Models;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    public class PeriodController : AdminBaseController
    {
        private readonly IMunicipalityService municipalityService;
        private readonly ICommonService commonService;

        public PeriodController(
            IMunicipalityService _municipalityService,
            ICommonService _commonService)
        {
            municipalityService = _municipalityService;
            commonService = _commonService; 
        }

        public async Task<IActionResult> Index()
        {
            //AddPeriodViewModel model = new AddPeriodViewModel();    
           // model.Municipalities = await municipalityService.GetAllMunicipalitiesAsync();
            return View();
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

    }
}
