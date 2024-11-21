using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Municipality
{
    public class RegionViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int RegionId { get; set; }

        [Required]  
        public string RegionName { get; set; } = string.Empty;
    }
}
