using MunicipalityDebtsSystem.Core.Models.Cover;
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
    }
}
