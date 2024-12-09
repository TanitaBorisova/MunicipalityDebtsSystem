using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Models.Common;
using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityDebtsSystem.Areas.Admin.Models
{
    public class AddPeriodViewModel
    {
        [Required]
        [Comment("Starting date of the period")]
        public DateTime PeriodStart { get; set; }

        [Required]
        [Comment("Ending date of the period")]
        public DateTime PeriodEnd { get; set; }

        [Required]
        
        [MaxLength(ValidationConstants.MonthMaxLength)]
        public string Month { get; set; } = string.Empty;


        [Required]
       
        [MaxLength(ValidationConstants.YearMaxLength)]
        public string Year { get; set; } = string.Empty;

        [Required]
       
        public int MonthInt { get; set; }

        [Required]
        [Comment("Year of the period like integer")]
        public int YearInt { get; set; }

        [Required]
       
        public int MunicipalityId { get; set; }

        public List<MunicipalityViewModel> Municipalities { get; set; } = new List<MunicipalityViewModel>();

        public List<MonthViewModel> Months { get; set; } = new List<MonthViewModel>();

        public List<YearViewModel> Years { get; set; } = new List<YearViewModel>();

    }
}
