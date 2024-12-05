using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Debt
{
    public class DetailDebtViewModel
    {

        public int Id { get; set; }   //DebtId

        public string DebtNumber { get; set; } = string.Empty;
               
        public string ResolutionNumber { get; set; } = string.Empty;

        public string DateBook { get; set; } = string.Empty;

        //[Required]
        //public DateTime DateNegotiate { get; set; }

        public string DateContractFinish { get; set; } = string.Empty;

        public string DateRealFinish { get; set; } = string.Empty;


        public string CurrencyName { get; set; } = string.Empty;

        public string DebtAmountOriginalCcy { get; set; } = string.Empty;
                        
        public string DebtAmountLocalCcy { get; set; } = string.Empty;  
               
        public string CreditTypeName { get; set; } = string.Empty;

        public string CreditorTypeName { get; set; } = string.Empty;

        public string DebtTermTypeName { get; set; } = string.Empty;

        public string DebtPurposeTypeName { get; set; } = string.Empty;

        public string InterestTypeName { get; set; } = string.Empty;

        public string InterestRate { get; set; } = string.Empty;

        public int MunicipalityId { get; set; } 

        public string MunicipalityCode { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string UserCreated { get; set; } = string.Empty;
                
        public string DateCreated { get; set; } = string.Empty;
    }
}
