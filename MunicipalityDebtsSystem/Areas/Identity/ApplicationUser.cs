using Microsoft.AspNetCore.Identity;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityDebtsSystem.Areas.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int DataEbkId { get; set; }

        [ForeignKey(nameof(DataEbkId))]
        public EBK DataEbk { get; set; } = null!;
    }
}
