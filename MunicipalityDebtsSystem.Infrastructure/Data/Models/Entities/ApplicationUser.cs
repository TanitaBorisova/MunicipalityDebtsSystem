using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        //[Required]
        //[Range(1, int.MaxValue)]  // to do constants
        //public int RegionId { get; set; }

        //[Required]
        public int? MunicipalityId { get; set; }
    }
}
