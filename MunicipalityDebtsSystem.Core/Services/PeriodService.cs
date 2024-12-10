using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.PeriodList;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;


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

        public async Task<bool> IsPeriodExistsAndIsUnlock(int municipalityId, int monthInt, int yearInt)
        {
            bool result = false;
            result = await repository.AllReadOnly<PeriodList>()
                        .AnyAsync(p => p.MunicipalityId == municipalityId && p.MonthInt == monthInt && p.YearInt == yearInt && p.IsUnlock == true);
                 
            return result;
        
        }

        public async Task<PeriodListViewModel> GetPeriodsByMun(int municipalityId)
        {

            var periods = await repository.AllReadOnly<PeriodList>()
                        .Where(p => p.MunicipalityId == municipalityId && p.IsUnlock == true)
                        .Include(p=> p.Municipality)
                        .Select(p => new PeriodListViewModel
                        {
                            MonthName = p.MonthName,
                            YearName = p.YearName,
                            MunicipalityId = p.MunicipalityId,
                            MunicipalityCode = p.Municipality.MunicipalCode,
                            MunicipalityName = p.Municipality.Name,
                            UserUnlocked = p.UserNameUnlock,
                            DateUnlocked = p.DateUnlock.ToString(ValidationConstants.DateFormat),
                            IsUnlock = p.IsUnlock
                        })
                        .FirstOrDefaultAsync();

            return periods;

        }


    }
}
