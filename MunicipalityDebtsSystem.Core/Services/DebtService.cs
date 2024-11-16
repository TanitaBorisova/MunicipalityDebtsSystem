using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
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
        public async Task<List<CurrencyViewModel>> GetAllCurrenciesAsync()
        {
            return await repository.AllReadOnly<Currency>()

                .Select(c => new CurrencyViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<CreditorTypeViewModel>> GetAllCreditorTypesAsync()
        {
            return await repository.AllReadOnly<CreditorType>()

                .Select(c => new CreditorTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<CreditTypeViewModel>> GetAllCreditTypesAsync()
        {
            return await repository.AllReadOnly<CreditType>()

                .Select(c => new CreditTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<DebtPurposeTypeViewModel>> GetAllDebtPurposeTypesAsync()
        {
            return await repository.AllReadOnly<DebtPurposeType>()

                .Select(c => new DebtPurposeTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<InterestTypeViewModel>> GetAllInterestTypesAsync()
        {
            return await repository.AllReadOnly<InterestType>()

                .Select(c => new InterestTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<DebtTermTypeViewModel>> GetAllDebtTermTypesAsync()
        {
            return await repository.AllReadOnly<DebtType>()

                .Select(c => new DebtTermTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

    }
}
