using MunicipalityDebtsSystem.Core.Models.Debt;
using System.ComponentModel.DataAnnotations;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;

namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class AddPlannedDrawViewModel
    {
        [Required]
        public int DebtId { get; set; }

        public int? DrawParentId { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Дата на планирано усвояване")]
        public string DrawDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Размер на планирано усвояване")]
        public decimal DrawAmount { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        public bool IsFinished { get; set; }

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();
    }
}
