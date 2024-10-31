using Microsoft.EntityFrameworkCore;
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
        public int Id { get; set; }

        [Required]
        public int DebtId { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        [Required]
        public decimal CoverAmount { get; set; }

        public string? CoverDescription { get; set; }

        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        [ForeignKey(nameof(CoverTypeId))]
        public CoverType CoverType { get; set; } = null!;
    }
}
