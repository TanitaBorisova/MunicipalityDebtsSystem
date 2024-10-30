using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities
{
    [Table("Debts", Schema = "mundebt")]
    [Comment("Table for storing municipalities debts")]
    public class Debt
    {

        public Debt()
        {
            CreditStatusId = 1;
            IsNegotiated = false;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey(nameof(Id))]
        public int DebtParentId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DebtNumberMaxLength)]
        public string DebtNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstants.ResolutionNumberMaxLength)]
        public string ResolutionNumber { get; set; } = string.Empty;


        [Required]
        public DateTime DateBook { get; set; }

        [Required]
        public DateTime DateNegotiate { get; set; }

        [Required]
        public DateTime DateContractFinish { get; set; }

        [Required]
        public DateTime DateRealFinish { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DebtCurrencyMaxLength)]
        public string DebtCurrency { get; set; } = string.Empty;

        [Required]
        public decimal DebtAmountOriginalCcy { get; set; }


        [Required]
        public decimal DebtAmountLocalCcy { get; set; }

        [Required]
        public int CreditTypeId { get; set; }

        [Required]
        public int CreditorTypeId { get; set; }

        [Required]
        public int DebtTermTypeId { get; set; }

        [Required]
        public int DebtPurposeTypeId { get; set; }

        [Required]
        public int InterestTypeId { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [ForeignKey(nameof(InterestTypeId))]
        public InterestType InterestType { get; set; } = null!;

        [Required]
        public int CreditStatusId { get; set; }

        [Required]
        public int DataEbkId { get; set; }

        [Required]
        public bool IsNegotiated { get; set; }

        [Required]
        public string UserCreated { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        
        public string? UserModified { get; set; }
                
        public DateTime? DateModified { get; set; }

        public string? UserDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(CreditStatusId))]
        public CreditStatusType CreditStatusType { get; set; } = null!;

        [ForeignKey(nameof(DebtTermTypeId))]
        public DebtType DebtType { get; set; } = null!;

        [ForeignKey(nameof(DebtPurposeTypeId))]
        public DebtPurposeType DebtPurposeType { get; set; } = null!;

        [ForeignKey(nameof(CreditTypeId))]
        public CreditType CreditType { get; set; } = null!;

        [ForeignKey(nameof(CreditorTypeId))]
        public CreditorType CreditorType { get; set; } = null!;

        [ForeignKey(nameof(DataEbkId))]
        public EBK EBK { get; set; } = null!;

    }
}
