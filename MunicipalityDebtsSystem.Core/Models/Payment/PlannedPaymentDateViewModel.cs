using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Payment
{
    public class PlannedPaymentDateViewModel
    {
        public int Id { get; set; }

        public string PlannedDate { get; set; } = string.Empty;
    }
}
