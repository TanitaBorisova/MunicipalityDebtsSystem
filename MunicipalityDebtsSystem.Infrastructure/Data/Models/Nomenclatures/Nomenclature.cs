using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{

    public abstract class Nomenclature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.NomenclatureNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
