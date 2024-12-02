using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
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

        Task AddAsync(AddDrawViewModel model, string userId, int municipalityId, DateTime dateDraw);
    }
}
