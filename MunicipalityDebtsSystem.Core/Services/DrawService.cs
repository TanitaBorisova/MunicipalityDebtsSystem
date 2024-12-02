using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OperationTypeId =(int)OperationType.PlannedPayment,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(draw);
            await repository.SaveChangesAsync();

        }

        public async Task AddAsync(AddDrawViewModel model, string userId, int municipalityId, DateTime dateDraw)
        {
            Draw draw = new Draw
            {

                DebtId = model.DebtId,
                DrawParentId = model.DrawParentId,
                DrawDate = dateDraw,
                DrawAmount = model.DrawAmount,
                OperationTypeId = (int)OperationType.PlannedPayment,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(draw);
            await repository.SaveChangesAsync();

        }

       
    }
}
