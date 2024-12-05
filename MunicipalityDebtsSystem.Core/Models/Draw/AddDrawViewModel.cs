using MunicipalityDebtsSystem.Core.Models.Debt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;


namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class AddDrawViewModel
    {
        [Required]
        public int DebtId { get; set; }

        [Required]
        //[Range(1, int.MaxValue)]
        public int DrawParentId { get; set; }


        //[Required(ErrorMessage = RequiredErrorMessage)]
        //[Display(Name = "Дата на планирано усвояване")]
        //public string DrawPlannedDate { get; set; } = string.Empty;
        
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Размер на планирано усвояване")]
       
        public decimal DrawPlannedAmount { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Дата на реално усвояване")]
        public string DrawDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Размер на рееално усвояване")]
        public decimal DrawAmount { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Дата на планирано усвояване")]
        //[Range(3,3)]  //Draw
        public int OperationTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]  //Draw
        public int PlannedDrawId { get; set; }


        public string MunicipalityCode { get; set; } = string.Empty;

        
        public string MunicipalityName { get; set; } = string.Empty;

        public List<PlannedDrawDateViewModel> PlannedDrawDates { get; set; } = new List<PlannedDrawDateViewModel>();
    }
}
