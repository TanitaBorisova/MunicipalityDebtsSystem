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

    [Table("MunicipalsCenters", Schema = "nomenclatures")]
    [Comment("Table for all regions in BG")]
    public class MunicipalCenter : Nomenclature
    {
        [MaxLength(ValidationConstants.MunicipalCenterCodeMaxLength)]
        public string MunicipalCenterCode { get; set; } = string.Empty;
    }
}
