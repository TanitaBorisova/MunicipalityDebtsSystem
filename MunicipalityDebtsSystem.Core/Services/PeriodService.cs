using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MunicipalityDebtsSystem.Core.Services
{
    public class PeriodService : IPeriodService
    {
        private readonly IRepository repository;

        public PeriodService(IRepository _repository)
        {
            repository = _repository;       
        }
        public async Task AddAsync(PeriodList period)
        {
           
            await repository.AddAsync(period);
            await repository.SaveChangesAsync();

        }
    }
}
