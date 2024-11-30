

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class DebtListViewModel
    {
        public int DebtId { get; set; }

        public int DebtParentId { get; set; }

        public string DebtNumber { get; set; } = string.Empty;

        public string DebtParentNumber { get; set; } = string.Empty;


        public string ResolutionNumber { get; set; } = string.Empty;

        public string DateBook { get; set; } = string.Empty;

        //[Required]
        //public DateTime DateNegotiate { get; set; }

        public string DateContractFinish { get; set; } = string.Empty;

       // public string DateRealFinish { get; set; } = string.Empty;

           public string DebtAmountOriginalCcy { get; set; } = string.Empty;

        public string CurrencyName { get; set; } = string.Empty;

        // public string DebtAmountLocalCcy { get; set; } = string.Empty;

        public string CreditTypeName { get; set; } = string.Empty;

        //public string CreditorTypeName { get; set; } = string.Empty;

        //public string DebtTermTypeName { get; set; } = string.Empty;

        //public string DebtPurposeTypeName { get; set; } = string.Empty;

        //public string InterestTypeName { get; set; } = string.Empty;

        //public string InterestRate { get; set; } = string.Empty;

        public int MunicipalityId { get; set; }

        public string MunicipalityCode { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string StatusName { get; set; } = string.Empty;



    }
}
