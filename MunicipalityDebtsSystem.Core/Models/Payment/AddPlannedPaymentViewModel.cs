using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Payment
{
    public class AddPlannedPaymentViewModel
    {
        // public int Id { get; set; }

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

        public string? Comment { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        [Required]
        public int MunicipalityId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string UserCreated { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; }

            
        [Required]
        public bool IsDeleted { get; set; }

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();
    }
}
