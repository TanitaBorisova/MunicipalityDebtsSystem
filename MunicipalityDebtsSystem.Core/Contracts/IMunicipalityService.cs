using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IMunicipalityService
    {
        Task<List<RegionViewModel>> GetAllRegionsAsync();

        Task<List<MunicipalityViewModel>> GetAllMunicipalitiesAsync();

        Task<RegionViewModel?> GetRegionByIdAsync(int regionId);

        Task<MunicipalityViewModel?> GetMunicipalityByIdAsync(int municipalityId);

        Task<List<MunicipalityViewModel>> GetMunicipalitiesByRegionIdAsync(int regionId);

        Task<List<Municipality>> GetMunicipalitiesByNameAsync(string searchTerm);
    }
}
