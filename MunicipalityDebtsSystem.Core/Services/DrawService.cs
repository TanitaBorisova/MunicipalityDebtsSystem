﻿using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
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
                DateCreated = DateTime.Now,
               
                
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

        public async Task<List<PlannedDrawDateViewModel>> GetAllPlannedDrawDatesAsync(int debtId) 
        {
            return await repository.AllReadOnly<Draw>()
                .Where(d=> d.OperationTypeId == (int)OperationType.PlannedDraw && d.DebtId == debtId)

                .Select(c => new PlannedDrawDateViewModel
                {
                    Id = c.Id,
                    PlannedDate = c.DrawDate.ToString(ValidationConstants.DateFormat)
                }).ToListAsync();
        }
      
       
        public async Task<Draw> GetPlannedDrawInfoByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync<Draw>(id);
            return entity;
        }

        public async Task<IEnumerable<PlannedDrawListViewModel>> GetAllPlannedDrawsAsync(int id)  
        {
            var model = await repository.AllReadOnly<Draw>()
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.PlannedDraw && d.Debt.Id == id) 
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)
                     
                .Select(d => new PlannedDrawListViewModel
                {
                    
                    DrawId = d.Id,
                    DrawDate = d.DrawDate.ToString(ValidationConstants.DateFormat),
                    DrawAmount = d.DrawAmount,
                    IsDebtFinished = d.Debt.IsFinished

                }).ToListAsync();


            return model;

        }

        public async Task<IEnumerable<DrawListViewModel>> GetAllDrawsAsync(int id)  
        {
            var model = await repository.AllReadOnly<Draw>()
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.Draw && d.Debt.Id == id)  
                .Include(d=> d.ParentDraw)
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)

                .Select(d => new DrawListViewModel
                {
                   
                    DrawId = d.Id,
                    DrawDate = d.DrawDate.ToString(ValidationConstants.DateFormat),
                    DrawAmount = d.DrawAmount,
                    DrawParentId = d.DrawParentId ?? 0,
                    DrawParentAmount = d.ParentDraw.DrawAmount,
                    DrawParentDate = d.ParentDraw.DrawDate.ToString(ValidationConstants.DateFormat),
                    IsDebtFinished = d.Debt.IsFinished


                }).ToListAsync();


            return model;

        }

        public async Task<Draw> GetDrawEntityByIdAsync(int id)
        {
            return await repository.GetByIdAsync<Draw>(id);
 
               
        }

        public async Task<bool> PlannedDrawHasChildsAsync(int id)
        {
           
            bool hasChildDraws = await repository.AllReadOnly<Draw>()
                   .AnyAsync(d => d.DrawParentId == id);  
            return hasChildDraws;   
        }


        public async Task RemoveDraw(int id)
        {
          await repository.DeleteAsync<Draw>(id);
          await repository.SaveChangesAsync();
        }

                         
    }
}
