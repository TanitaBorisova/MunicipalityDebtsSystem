using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MunicipalityDebtsSystem.Core.Constants.AdminConstants;

namespace MunicipalityDebtsSystem.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
