

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class DebtListViewModel
    {
       // [JsonPropertyName("iDebtId")]
        public int Id { get; set; }

        public string DebtNumber { get; set; } = string.Empty;

        public string DebtParentNumber { get; set; } = string.Empty;

        public string ResolutionNumber { get; set; } = string.Empty;

        public string DateBook { get; set; } = string.Empty;

        public string DateContractFinish { get; set; } = string.Empty;

        public string DebtAmountOriginalCcy { get; set; } = string.Empty;

        public string CurrencyName { get; set; } = string.Empty;
              
        public string MunicipalityCode { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string StatusName { get; set; } = string.Empty;


    }
}
