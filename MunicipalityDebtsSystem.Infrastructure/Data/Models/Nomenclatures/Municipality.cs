using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{

    [Table("Municipalities", Schema = "nomenclatures")]
    [Comment("Table for all municipalities in BG")]
    public class Municipality: Nomenclature
    {
        [Required]
        [MaxLength(ValidationConstants.MunicipaliryCodeMaxLength)]
        public string MunicipalCode { get; set; } = string.Empty;

        [Required]
        public int MunicipalCenterId { get; set; }

        [ForeignKey(nameof(MunicipalCenterId))]
        public MunicipalCenter MunicipalCenter { get; set; } = null!;
    }
}
