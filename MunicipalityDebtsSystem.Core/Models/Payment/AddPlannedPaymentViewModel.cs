using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityDebtsSystem.Core.Models.Payment
{
    public class AddPlannedPaymentViewModel
    {
        

        [Required]
        public int DebtId { get; set; }

        public int? PaymentParentId { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public string PaymentDate { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal InterestAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal OperateTaxAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal InterestRate { get; set; }

        public bool IsFinished { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        [Required]
        public int MunicipalityId { get; set; }

                   
        [Required]
        public bool IsDeleted { get; set; }

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();
    }
}
