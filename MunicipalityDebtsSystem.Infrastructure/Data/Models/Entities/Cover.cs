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

    [Table("Covers", Schema = "mundebt")]
    [Comment("Table for storing covers of the debts")]
    public class Cover
    {
        [Key]
        [Comment("Identifier of the cover")]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the debt")]
        public int DebtId { get; set; }

        [Required]
        [Comment("Identifier of the cover type")]
        public int CoverTypeId { get; set; }

        [Required]
        [Comment("Amount of the cover")]
        public decimal CoverAmount { get; set; }

        [Comment("Description of the cover")]
        public string? CoverDescription { get; set; }

        [Required]
        [Comment("User created the cover")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string UserCreated { get; set; } = string.Empty;

        [Required]
        [Comment("Date creation of the cover")]
        public DateTime DateCreated { get; set; }


        [Comment("User marked the cover as deleted")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserDeleted { get; set; }

        [Comment("Date of deletion of the cover")]
        public DateTime? DateDeleted { get; set; }

        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        [Required]
        [Comment("Identifier of Municipality")]
        public int MunicipalityId { get; set; }

        [ForeignKey(nameof(CoverTypeId))]
        public CoverType CoverType { get; set; } = null!;

        [ForeignKey(nameof(MunicipalityId))]
        public Municipality Municipality { get; set; } = null!;
    }
}
