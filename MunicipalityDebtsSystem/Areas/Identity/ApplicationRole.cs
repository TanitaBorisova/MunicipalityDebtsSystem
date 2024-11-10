using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityDebtsSystem.Areas.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [Required]
        public string RoleNameBG { get; set; } = null!;
    }
}
