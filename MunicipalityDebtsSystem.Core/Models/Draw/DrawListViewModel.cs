using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class DrawListViewModel
    {
        public int DebtId { get; set; }

        public int DrawId { get; set; }

        public string DrawDate { get; set; } = string.Empty;

        public decimal DrawAmount { get; set; }

        public int DrawParentId { get; set; }

        public string DrawParentDate { get; set; } = string.Empty;

        public decimal DrawParentAmount { get; set; }

        public bool IsDebtFinished { get; set; }
    }
}
