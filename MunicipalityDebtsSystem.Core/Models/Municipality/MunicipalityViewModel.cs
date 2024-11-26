using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Municipality
{
    public class MunicipalityViewModel
    {

        [Required]
        [Range(1, int.MaxValue)]
        public int MunicipalityId { get; set; }

        [Required]
        public string MunicipalityName { get; set; } = string.Empty;

        [Required]
        public string MunicipalityCode { get; set; } = string.Empty;
    }
}
