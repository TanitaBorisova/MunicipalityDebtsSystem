using MunicipalityDebtsSystem.Core.Models.Cover;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface ICoverService
    {
        Task<List<CoverViewModel>> GetAllCoversAsync();

        Task AddCoverAsync(AddCoverViewModel model, string userId, int municipalityId);

        Task<IEnumerable<CoverListViewModel>> GetAllCoversAsync(int id);

        Task RemoveCover(int id);

        Task<Cover> GetCoverEntityByIdAsync(int id);
    }
}
