using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IDebtService
    {
        Task AddAsync(AddDebtViewModel model, string userId, int municipalityId);

        Task EditAsync(EditDebtViewModel model, string userId, int municipalityId);

        Task<DetailDebtViewModel> GetDebtByIdAsync(int id, string userId);

        Task<Debt> GetEntityDebtById(int id);

        Task<List<CurrencyViewModel>> GetAllCurrenciesAsync();

        Task<List<CreditorTypeViewModel>> GetAllCreditorTypesAsync();

        Task<List<CreditTypeViewModel>> GetAllCreditTypesAsync();

        Task<List<DebtPurposeTypeViewModel>> GetAllDebtPurposeTypesAsync();

        Task<List<InterestTypeViewModel>> GetAllInterestTypesAsync();

        Task<List<DebtTermTypeViewModel>> GetAllDebtTermTypesAsync();

        Task<bool> CheckCurrencyExistAsync(int id);

        Task<bool> CheckCreditTypeExistAsync(int id);

        Task<bool> CheckCreditorTypeExistAsync(int id);

        Task<bool> CheckDebtTermTypeExistAsync(int id);

        Task<bool> CheckDebtPurposeTypeExistAsync(int id);

        Task<bool> CheckInterestTypeExistAsync(int id);
    }
}
