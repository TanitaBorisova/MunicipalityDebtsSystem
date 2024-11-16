using MunicipalityDebtsSystem.Core.Models.Debt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IDebtService
    {
        Task AddAsync(AddDebtViewModel model);
    }
}
