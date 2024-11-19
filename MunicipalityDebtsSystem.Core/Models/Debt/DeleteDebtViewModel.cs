using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class DeleteDebtViewModel
    {
        public int Id { get; set; }

        public string DebtNumber { get; set; } = string.Empty;
               
        public string DateBook { get; set; } = string.Empty;

        public string DateContractFinish { get; set; } = string.Empty;

        public string CurrencyName { get; set; } = string.Empty;

        public string DebtAmountOriginalCcy { get; set; } = string.Empty;

        public string DebtAmountLocalCcy { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string MunicipalityCode { get; set; } = string.Empty;

        public bool IsAnex { get; set; }

    }
}
