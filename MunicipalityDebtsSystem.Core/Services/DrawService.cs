using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationType = MunicipalityDebtsSystem.Core.Enums.OperationType;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class DrawService : IDrawService
    {
        private readonly IRepository repository;

        public DrawService(IRepository _repository)
        {
            repository = _repository;        
        }


        public async Task AddPlannedAsync(AddPlannedDrawViewModel model, string userId, int municipalityId, DateTime dateDraw)
        {
            Draw draw = new Draw
            {
              
                DebtId = model.DebtId,
                DrawParentId = null,
                DrawDate = dateDraw,    
                DrawAmount = model.DrawAmount,
                OperationTypeId =(int)OperationType.PlannedDraw,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now
                
            };

            await repository.AddAsync(draw);
            await repository.SaveChangesAsync();

        }

        public async Task AddRealAsync(AddDrawViewModel model, string userId, int municipalityId, DateTime dateDraw, int drawParentId)
        {
            Draw draw = new Draw
            {

                DebtId = model.DebtId,
                DrawParentId = drawParentId,
                DrawDate = dateDraw,
                DrawAmount = model.DrawAmount,
                OperationTypeId = (int)OperationType.Draw,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(draw);
            await repository.SaveChangesAsync();

        }

        public async Task<List<PlannedDrawDateViewModel>> GetAllPlannedDrawDatesAsync(int debtId) //int debtId
        {
            return await repository.AllReadOnly<Draw>()
                .Where(d=> d.OperationTypeId == (int)OperationType.PlannedDraw && d.DebtId == debtId)

                .Select(c => new PlannedDrawDateViewModel
                {
                    Id = c.Id,
                    PlannedDate = c.DrawDate.ToString(ValidationConstants.DateFormat)
                }).ToListAsync();
        }
        //GetPlannedPaymentInfo(plannedDrawId)
        public async Task<Draw> GetPlannedDrawInfoByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync<Draw>(id);
            return entity;
        }

        public async Task<IEnumerable<PlannedDrawListViewModel>> GetAllPlannedDrawsAsync()  //int id
        {
            var model = await repository.AllReadOnly<Draw>()
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.PlannedDraw)  //&& d.Debt.Id == id
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)
                     
                .Select(d => new PlannedDrawListViewModel
                {
                    // //= d.DebtId,
                    ////DrawId = d.
                    DrawDate = d.DrawDate.ToString(ValidationConstants.DateFormat),
                    DrawAmount = d.DrawAmount

                }).ToListAsync();


            return model;

        }

    }
}
