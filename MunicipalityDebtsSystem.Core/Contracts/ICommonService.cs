using MunicipalityDebtsSystem.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface ICommonService
    {
        List<YearViewModel> GetYears();

        List<MonthViewModel> GetMonths();
    }
}
