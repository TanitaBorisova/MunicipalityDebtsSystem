using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MunicipalityDebtsSystem.Controllers
{
    //[Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        

        //public IActionResult Index()
        //{

        //    return View();
        //}
    }
}
