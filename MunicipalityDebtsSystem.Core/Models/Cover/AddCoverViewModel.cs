using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Cover
{
    public class AddCoverViewModel
    {

        [Required]
        public int DebtId { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredErrorMessage)]
        public decimal CoverAmount { get; set; }

        public string? CoverDescription { get; set; }

        public bool IsFinished { get; set; }

        public List<CoverViewModel> CoverTypes { get; set; } = new List<CoverViewModel>();

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();
    }
}
