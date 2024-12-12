using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Payment
{
    public class AddPaymentViewModel
    {
        // public int Id { get; set; }

        [Required]
        public int DebtId { get; set; }

        public int PlannedPaymentId { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public string PaymentParentDate { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal PaymentParentAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal InterestParentAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal OperateTaxParentAmount { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal InterestParentRate { get; set; }

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

        public string? ParentComment { get; set; }

        public string? RealComment { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        [Required]
        public int MunicipalityId { get; set; }

        //[Required]
        //[MaxLength(ValidationConstants.UserMaxLength)]
        //public string UserCreated { get; set; } = string.Empty;

        //[Required]
        //public DateTime DateCreated { get; set; }


        [Required]
        public bool IsDeleted { get; set; }

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();

        //[Required]
        //[Range(1, int.MaxValue)]
        //public int PlannedPaymentId { get; set; }


        //public string MunicipalityCode { get; set; } = string.Empty;


        //public string MunicipalityName { get; set; } = string.Empty;

        public List<PlannedPaymentDateViewModel> PlannedPaymentDates { get; set; } = new List<PlannedPaymentDateViewModel>();

        
    }
}
