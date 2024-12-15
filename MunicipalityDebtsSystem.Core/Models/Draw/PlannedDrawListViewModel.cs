using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class PlannedDrawListViewModel
    {
        public int DebtId { get; set; }

        //public int? DrawParentId { get; set; }

        public int DrawId { get; set; }
        public string DrawDate { get; set; } = string.Empty;

        public decimal DrawAmount { get; set; }

        public bool IsDebtFinished { get; set; }
    }
}
