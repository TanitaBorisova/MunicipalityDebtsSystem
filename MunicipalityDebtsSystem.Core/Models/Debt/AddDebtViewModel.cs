﻿using System.ComponentModel.DataAnnotations;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;
namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class AddDebtViewModel
    {
        public string MunicipalityName { get; set; } = string.Empty;

        public string MunicipalitCode { get; set; } = string.Empty;

        public int DebtParentId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DebtNumberMaxLength, MinimumLength = DebtNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
       
        public string DebtNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ResolutionNumberMaxLength, MinimumLength = ResolutionNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string ResolutionNumber { get; set; } = string.Empty;

       
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime DateBook { get; set; }

        //[Required]
        //public DateTime DateNegotiate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime DateContractFinish { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime DateRealFinish { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CurrencyMinValue, int.MaxValue)]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal DebtAmountOriginalCcy { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal DebtAmountLocalCcy { get; set; }
        
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CreditTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CurrencyMinValue, int.MaxValue)]
        public int CreditorTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CurrencyMinValue, int.MaxValue)]
        public int DebtTermTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CurrencyMinValue, int.MaxValue)]
        public int DebtPurposeTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CurrencyMinValue, int.MaxValue)]
        public int InterestTypeId { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal InterestRate { get; set; }


        [Required]
        public int MunicipalityId { get; set; }
             
        //[Required]
        //[MinLength(2)]
        //[MaxLength(50)]
        //public string UserCreated { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; }

      
        public List<CurrencyViewModel> Currencies { get; set; } = new List<CurrencyViewModel>();
        public List<CreditTypeViewModel> CreditTypes { get; set; } = new List<CreditTypeViewModel>();
        public List<CreditorTypeViewModel> CreditorTypes { get; set; } = new List<CreditorTypeViewModel>();
        public List<DebtTermTypeViewModel> DebtTermTypes { get; set; } = new List<DebtTermTypeViewModel>();
        public List<DebtPurposeTypeViewModel> DebtPurposeTypes { get; set; } = new List<DebtPurposeTypeViewModel>();
        public List<InterestTypeViewModel> InterestTypes { get; set; } = new List<InterestTypeViewModel>();
    }
}