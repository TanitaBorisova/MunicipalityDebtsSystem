using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Cover
{
    public class CoverListViewModel
    {
        [Required]
        public int CoverId { get; set; }

        [Required]
        public string CoverTypeName{ get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal CoverAmount { get; set; }

        public string? CoverDescription { get; set; }
    }
}
