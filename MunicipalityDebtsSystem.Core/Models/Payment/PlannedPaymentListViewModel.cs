using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Payment
{
    public class PlannedPaymentListViewModel
    {
        public int DebtId { get; set; }

        public int PaymentId { get; set; }

        public string PaymentDate { get; set; } = string.Empty;

        public decimal PaymentAmount { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal InterestRate { get; set; }

        public decimal OperateTaxAmount { get; set; }
    }
}
