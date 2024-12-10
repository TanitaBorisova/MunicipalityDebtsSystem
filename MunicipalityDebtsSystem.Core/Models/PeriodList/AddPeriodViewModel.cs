using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Models.Common;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;

namespace MunicipalityDebtsSystem.Core.Models.PeriodList
{
    public class AddPeriodViewModel
    {
        [Required]
        public DateTime PeriodStart { get; set; }

        [Required]
        public DateTime PeriodEnd { get; set; }

       // [Required]
        [MaxLength(ValidationConstants.MonthMaxLength)]
        public string MonthName { get; set; } = string.Empty;

        //[Required]
        [MaxLength(ValidationConstants.YearMaxLength)]
        public string YearName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(1, 12)]
        public int MonthInt { get; set; }

        [Required]
         public bool IsUnlock { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(2020, int.MaxValue)]
        public int YearInt { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int MunicipalityId { get; set; }

        public List<MunicipalityViewModel> Municipalities { get; set; } = new List<MunicipalityViewModel>();

        public List<MonthViewModel> Months { get; set; } = new List<MonthViewModel>();

        public List<YearViewModel> Years { get; set; } = new List<YearViewModel>();

       

    }
}
