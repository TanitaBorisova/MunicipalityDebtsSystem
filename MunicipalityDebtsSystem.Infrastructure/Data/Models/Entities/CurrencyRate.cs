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

    [Table("CurrenciesRates", Schema = "mundebt")]
    [Comment("Table for currency rates")]
    public class CurrencyRate
    {
        [Key]
        [Required]
        [Comment("Identifier ot the rate")]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the currency")]
        public int CurrencyId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("Rate from foreign currency to local - BGN")]
        public decimal RateToBGN { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")] 
        [Comment("Rate from local - BGN to foreign currency")]
        public decimal RateFromBGN { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;
    }
}
