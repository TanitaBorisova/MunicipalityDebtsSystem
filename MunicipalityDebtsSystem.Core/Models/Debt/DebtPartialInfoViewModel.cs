using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class DebtPartialInfoViewModel
    {
        public string DebtNumber { get; set; } = string.Empty;

        public string BookDate { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string MunicipalityCode { get; set; } = string.Empty;

        public decimal PlannedDraws { get; set; }

        public decimal Draws { get; set; }

        public decimal PlannedPayments { get; set; }

        public decimal Payments { get; set; }

        public decimal PlannedRemainDebt { get; set; }

        public decimal RealRemainDebt { get; set; }

        public string CurrencyName { get; set; } = string.Empty;
    }
}
