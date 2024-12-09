using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IDebtService
    {
        Task<decimal> ReturnSumOfOperationType(int operType, int debtId);
        Task<IEnumerable<DebtListViewModel>> GetAllDebtAsync(int municipalityId);
        Task<IEnumerable<DebtListViewModel>> GetAllDebtAdminAsync();
        // Task<(IEnumerable<DebtListViewModel> debts, int totalRecords)> GetDebtsWithPagingAsync(int start, int length, string searchValue, string orderBy, string orderDir);
        // Task<List<Currency>> GetAllCurrenciesAsync();
        //Task<(IEnumerable<DebtListViewModel> debts, int totalRecords, int filteredRecords)> GetDebtsWithPagingAsync(int pageIndex, int pageSize, string searchValue);
        //Task<(IEnumerable<DebtListViewModel> debts, int totalRecords)> GetDebtsWithPagingAsync();

        //Task<IEnumerable<PlannedDrawListViewModel>> GetAllPlannedDrawsAsync(int id);

        Task<(List<DebtListViewModel> Debts, int TotalRecords, int FilteredRecords)> GetDebtsWithPagingAsync(int pageIndex, int pageSize, string searchValue);

        //Task<(List<DebtListViewModel> Debts, int TotalRecords, int FilteredRecords)> GetDebtsWithPagingAsync(int pageIndex, int pageSize);
        Task AddAsync(AddDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealFinish);

        Task EditAsync(EditDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealFinish);

        Task<DetailDebtViewModel> GetDebtByIdAsync(int id);

        Task<Debt> GetEntityDebtById(int id);

        Task NegotiateAsync(NegotiateDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealContractFinish);

        Task<CreditorType> GetEntityCreditorTypeById(int id);

        Task<CreditType> GetEntityCreditTypeById(int id);

        Task<DebtType> GetEntityDebtTermTypeById(int id);

        Task<DebtPurposeType> GetEntityDebtPurposeTypeById(int id);

        Task<List<CurrencyViewModel>> GetAllCurrenciesAsync();

        Task<List<CreditorTypeViewModel>> GetAllCreditorTypesAsync();

        Task<List<CreditTypeViewModel>> GetAllCreditTypesAsync();

        Task<List<DebtPurposeTypeViewModel>> GetAllDebtPurposeTypesAsync();

        Task<List<InterestTypeViewModel>> GetAllInterestTypesAsync();

        Task<List<DebtTermTypeViewModel>> GetAllDebtTermTypesAsync();
        Task DeleteDebt(Debt debt);

        Task<bool> CheckCurrencyExistAsync(int id);

        Task<bool> CheckCreditTypeExistAsync(int id);

        Task<bool> CheckCreditorTypeExistAsync(int id);

        Task<bool> CheckDebtTermTypeExistAsync(int id);

        Task<bool> CheckDebtPurposeTypeExistAsync(int id);

        Task<bool> CheckInterestTypeExistAsync(int id);
    }
}
