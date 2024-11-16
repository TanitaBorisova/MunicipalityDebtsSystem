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

        Task<List<CurrencyViewModel>> GetAllCurrenciesAsync();

        Task<List<CreditorTypeViewModel>> GetAllCreditorTypesAsync();

        Task<List<CreditTypeViewModel>> GetAllCreditTypesAsync();

        Task<List<DebtPurposeTypeViewModel>> GetAllDebtPurposeTypesAsync();

        Task<List<InterestTypeViewModel>> GetAllInterestTypesAsync();

        Task<List<DebtTermTypeViewModel>> GetAllDebtTermTypesAsync();
    }
}
