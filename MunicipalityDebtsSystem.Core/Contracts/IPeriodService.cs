using MunicipalityDebtsSystem.Core.Models.PeriodList;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;


namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IPeriodService
    {
        Task AddAsync(PeriodList period);

        Task<bool> IsPeriodExistsAndIsUnlock(int municipalityId, int monthInt, int yearInt);

        Task<PeriodListViewModel> GetPeriodsByMun(int municipalityId);
    }
}
