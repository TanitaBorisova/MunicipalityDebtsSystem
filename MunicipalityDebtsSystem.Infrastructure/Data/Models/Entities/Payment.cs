using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities
{
    [Table("Payments", Schema = "mundebt")]
    [Comment("Table for storing payments of the debt")]
    public class Payment
    {
        [Key]
        [Comment("Identifier of the payment")]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the debt")]
        public int DebtId { get; set; }


        [Comment("Identifier of the parent payment - populated for real payment")]
        public int? PaymentParentId { get; set; }

        [Required]
        [Comment("Date of the payment")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Comment("Amount of the payment")]
        public decimal PaymentAmount { get; set; }

        [Required]
        [Comment("Interest amount of the payment")]
        public decimal InterestAmount { get; set; }

        [Required]
        [Comment("Tax amount of the payment")]
        public decimal OperateTaxAmount { get; set; }

        [Required]
        [Comment("Interest rate of the payment")]
        public decimal InterestRate { get; set; }

   
        [Comment("Comment for the payment")]
        public string? Comment { get; set; }

        [Required]
        [Comment("Identifier of the debt")]
        public int OperationTypeId { get; set; }

        [Required]
        [Comment("Identifier of Municipality")]
        public int MunicipalityId { get; set; }

        [Required]
        [Comment("User created the payment")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string UserCreated { get; set; } = string.Empty;

        [Required]
        [Comment("Date creation of the payment")]
        public DateTime DateCreated { get; set; }

        [Comment("User modified the payment")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserModified { get; set; }

        [Comment("Date of modification of the payment")]
        public DateTime? DateModified { get; set; }

        [Comment("User marked the payment as deleted")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserDeleted { get; set; }

        [Comment("Date of deletion of the payment")]
        public DateTime? DateDeleted { get; set; }

        [Required]
        [Comment("Shows if the payment is marked as deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(MunicipalityId))]
        public Municipality Municipality { get; set; } = null!;

        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        public Payment ParentPayment { get; set; } = null!;

        public ICollection<Payment> ChildPayments { get; set; } = null!; // Children
    }
}
