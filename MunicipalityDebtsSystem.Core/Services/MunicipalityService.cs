using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IRepository repository;
        public MunicipalityService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<List<RegionViewModel>> GetAllRegionsAsync()
        {
            return await repository.AllReadOnly<MunicipalCenter>()

                .Select(c => new RegionViewModel
                {
                    RegionId = c.Id,
                    RegionName = c.Name
                }).ToListAsync();
        }

        public async Task<List<MunicipalityViewModel>> GetAllMunicipalitiesAsync()
        {
            return await repository.AllReadOnly<Municipality>()

                .Select(c => new MunicipalityViewModel
                {
                    MunicipalityId = c.Id,
                    MunicipalityName = c.Name
                }).ToListAsync();
        }

        public async Task<RegionViewModel?> GetRegionByIdAsync(int regionId)
        {
            return await repository.AllReadOnly<MunicipalCenter>()
                .Where(r => r.Id== regionId && r.IsDeleted == false)
                .Select(c => new RegionViewModel
                {
                    RegionId = c.Id,
                    RegionName = c.Name
                }).FirstOrDefaultAsync();
        }

        public async Task<MunicipalityViewModel?> GetMunicipalityByIdAsync(int municipalityId)
        {
            return await repository.AllReadOnly<Municipality>()
                .Where(m => m.Id == municipalityId && m.IsDeleted == false)
                .Select(c => new MunicipalityViewModel
                {
                    MunicipalityId = c.Id,
                    MunicipalityName = c.Name,
                    MunicipalityCode = c.MunicipalCode
                }).FirstOrDefaultAsync();
        }

        public async Task<List<MunicipalityViewModel>> GetMunicipalitiesByRegionIdAsync(int regionId)
        {
            return await repository.AllReadOnly<Municipality>()
                .Where(m => m.MunicipalCenterId == regionId && m.IsDeleted == false)
                .Select(c => new MunicipalityViewModel
                {
                    MunicipalityId = c.Id,
                    MunicipalityName = c.Name
                }).ToListAsync();
        }

        public async Task<List<Municipality>> GetMunicipalitiesByNameAsync(string searchTerm)
        {
            return await repository.AllReadOnly<Municipality>()
                .Where(m => m.Name.Contains(searchTerm))
                .OrderBy(m=> m.Name)
                .ToListAsync();
        }
    }
}
