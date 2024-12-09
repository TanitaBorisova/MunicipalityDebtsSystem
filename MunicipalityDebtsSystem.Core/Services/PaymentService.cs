﻿using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository repository;
        public PaymentService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task AddPlannedPaymentAsync(AddPlannedPaymentViewModel model, string userId, int municipalityId, DateTime datePayment)
        {
            Payment payment = new Payment
            {

                DebtId = model.DebtId,
                PaymentParentId = null,
                PaymentDate = datePayment,
                PaymentAmount = model.PaymentAmount,
                InterestAmount = model.InterestAmount,
                InterestRate = model.InterestRate,
                OperateTaxAmount = model.OperateTaxAmount,
                Comment = model.Comment,
                OperationTypeId = (int)OperationType.PlannedPayment,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(payment);
            await repository.SaveChangesAsync();

        }
        public async Task<bool> PlannedPaymentHasChildsAsync(int id)
        {

            bool hasChildPayments = await repository.AllReadOnly<Payment>()
                   .AnyAsync(d => d.PaymentParentId == id);
            return hasChildPayments;
        }


        public async Task RemovePayment(int id)
        {
            await repository.DeleteAsync<Payment>(id);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlannedPaymentListViewModel>> GetAllPlannedPaymentsAsync(int id)
        {
            var model = await repository.AllReadOnly<Payment>()
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.PlannedPayment && d.Debt.Id == id)  //&& d.Debt.Id == id
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)

                .Select(d => new PlannedPaymentListViewModel
                {
                    // //= d.DebtId,
                    PaymentId = d.Id,
                    PaymentDate = d.PaymentDate.ToString(ValidationConstants.DateFormat),
                    PaymentAmount = d.PaymentAmount,
                    InterestRate = d.InterestRate,  
                    InterestAmount = d.InterestAmount,  
                    OperateTaxAmount = d.OperateTaxAmount

                }).ToListAsync();


            return model;

        }

    }
}
