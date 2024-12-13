using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Cover;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class CoverService : ICoverService
    {
        private readonly IRepository repository;
        public CoverService(IRepository _repository)
        {
            repository = _repository;           
        }
        public async Task<List<CoverViewModel>> GetAllCoversAsync()
        {
            return await repository.AllReadOnly<CoverType>()

                .Select(c => new CoverViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task AddCoverAsync(AddCoverViewModel model, string userId, int municipalityId)
        {
            Cover cover = new Cover
            {

                DebtId = model.DebtId,
                CoverTypeId = model.CoverTypeId,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(cover);
            await repository.SaveChangesAsync();

        }

    }
}
