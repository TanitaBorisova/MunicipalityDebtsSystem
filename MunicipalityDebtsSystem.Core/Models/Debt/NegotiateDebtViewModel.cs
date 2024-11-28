using MunicipalityDebtsSystem.Infrastructure.Data.CustomValidations;
using System.ComponentModel.DataAnnotations;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class NegotiateDebtViewModel
    {
        public string MunicipalityName { get; set; } = string.Empty;

        public string MunicipalityCode { get; set; } = string.Empty;

        public int DebtId { get; set; }

        public int DebtParentId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DebtNumberMaxLength, MinimumLength = DebtNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = DisplayDebtNumber)]
        public string DebtNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ResolutionNumberMaxLength, MinimumLength = ResolutionNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = DisplayResolutionNumber)]
        public string ResolutionNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = DisplayDebtBook)]
        public string DateBook { get; set; } = string.Empty;

        //[Required]
        //public DateTime DateNegotiate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = DisplayDateContractFinish)]
        public string DateContractFinish { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = DisplayDateRealFinish)]
        public string DateRealFinish { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayCurrencyName)]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [GreaterThanZero]
        [Display(Name = DebtAmountOriginal)]
        public decimal DebtAmountOriginalCcy { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [GreaterThanZero]
        [Display(Name = DebtAmountLocal)]
        public decimal DebtAmountLocalCcy { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayDebtCreditName)]
        public int CreditTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayDebtCreditorName)]
        public int CreditorTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayDebtTermName)]
        public int DebtTermTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayDebtPurposeName)]
        public int DebtPurposeTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [NotZeroSelection]
        [Display(Name = DisplayDebtInterestName)]
        public int InterestTypeId { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal InterestRate { get; set; }


        [Required]
        public int MunicipalityId { get; set; }

        //[Required]
        //public string UserCreated { get; set; } = string.Empty;

        //[Required]
        //public DateTime DateCreated { get; set; }


        public List<CurrencyViewModel> Currencies { get; set; } = new List<CurrencyViewModel>();
        public List<CreditTypeViewModel> CreditTypes { get; set; } = new List<CreditTypeViewModel>();
        public List<CreditorTypeViewModel> CreditorTypes { get; set; } = new List<CreditorTypeViewModel>();
        public List<DebtTermTypeViewModel> DebtTermTypes { get; set; } = new List<DebtTermTypeViewModel>();
        public List<DebtPurposeTypeViewModel> DebtPurposeTypes { get; set; } = new List<DebtPurposeTypeViewModel>();
        public List<InterestTypeViewModel> InterestTypes { get; set; } = new List<InterestTypeViewModel>();
    }
}
