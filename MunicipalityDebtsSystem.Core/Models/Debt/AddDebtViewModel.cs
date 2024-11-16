using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;
namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class AddDebtViewModel
    {
       
        public int DebtParentId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DebtNumberMaxLength, MinimumLength = DebtNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
       
        public string DebtNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ResolutionNumberMaxLength, MinimumLength = ResolutionNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string ResolutionNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime DateBook { get; set; }

        [Required]
       
        public DateTime DateNegotiate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Comment("End date of the debt")]
        public DateTime DateContractFinish { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Comment("Date of real finish of the debt")]
        public DateTime DateRealFinish { get; set; }

        //[Required]
        //[DebtCurrencyMaxLength)]
        //[Comment("Currency of the debt")]
        //public string DebtCurrency { get; set; } = string.Empty;

        [Required]
        [Comment("Amount of the debt in original currency")]
        public decimal DebtAmountOriginalCcy { get; set; }


        [Required]
        [Comment("Amount of the debt in local currency")]
        public decimal DebtAmountLocalCcy { get; set; }

        [Required]
        [Comment("Identifier of credit type")]
        public int CreditTypeId { get; set; }

        [Required]
        [Comment("Identifier of creditor type")]
        public int CreditorTypeId { get; set; }

        [Required]
        [Comment("Identifier of debt type")]
        public int DebtTermTypeId { get; set; }

        [Required]
        [Comment("Identifier of debt purpose type")]
        public int DebtPurposeTypeId { get; set; }

        [Required]
        [Comment("Identifier of interest type")]
        public int InterestTypeId { get; set; }

        [Required]
        [Comment("Interest rate")]
        public decimal InterestRate { get; set; }

        [ForeignKey(nameof(InterestTypeId))]
        [Comment("Interest type")]
        public InterestType InterestType { get; set; } = null!;

        [Required]
        [Comment("Identifier of status of the credit")]
        public int CreditStatusId { get; set; }

        [Required]
        [Comment("Identifier of Municipality")]
        public int MunicipalityId { get; set; }

        [Required]
        [Comment("Shows whether the debt is negotiated")]
        public bool IsNegotiated { get; set; }

        [Required]
        [Comment("User created the debt")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string UserCreated { get; set; }

        [Required]
        [Comment("Date creation of the debt")]
        public DateTime DateCreated { get; set; }

        [Comment("User modified the debt")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserModified { get; set; }

        [Comment("Date of modification of the debt")]
        public DateTime? DateModified { get; set; }

        [Comment("User marked the debt as deleted")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserDeleted { get; set; }

        [Comment("Date of deletion of the debt")]
        public DateTime? DateDeleted { get; set; }

        [Required]
        [Comment("Shows if the debt is marked as deleted")]
        public bool IsDeleted { get; set; }
    }
}
