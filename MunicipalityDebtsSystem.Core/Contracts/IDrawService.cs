using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IDrawService
    {
        Task AddPlannedAsync(AddPlannedDrawViewModel model, string userId, int municipalityId, DateTime dateDraw);
        Task AddRealAsync(AddDrawViewModel model, string userId, int municipalityId, DateTime dateDraw, int drawParentId);

        Task<List<PlannedDrawDateViewModel>> GetAllPlannedDrawDatesAsync(int debtId);

        Task<Draw> GetPlannedDrawInfoByIdAsync(int id);

        Task<IEnumerable<PlannedDrawListViewModel>> GetAllPlannedDrawsAsync(int id);

        //Task<IEnumerable<PlannedDrawListViewModel>> GetAllPlannedDrawsAsync();
        Task<Draw> GetDrawEntityByIdAsync(int id);

        Task<bool> PlannedDrawHasChildsAsync(int id);

        Task RemoveDraw(int id);
    }
}
