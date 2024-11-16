using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class DebtService : IDebtService
    {
        private readonly IRepository repository;

        public DebtService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task AddAsync(AddDebtViewModel model)
        {
            throw new NotImplementedException();
        }

        
    }
}
