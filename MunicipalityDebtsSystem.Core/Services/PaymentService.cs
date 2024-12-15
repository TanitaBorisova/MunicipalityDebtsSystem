using Microsoft.EntityFrameworkCore;
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
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.PlannedPayment && d.Debt.Id == id)  
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)

                .Select(d => new PlannedPaymentListViewModel
                {
                    
                    PaymentId = d.Id,
                    PaymentDate = d.PaymentDate.ToString(ValidationConstants.DateFormat),
                    PaymentAmount = d.PaymentAmount,
                    InterestRate = d.InterestRate,  
                    InterestAmount = d.InterestAmount,  
                    OperateTaxAmount = d.OperateTaxAmount,
                    IsDebtFinished = d.Debt.IsFinished

                }).ToListAsync();


            return model;

        }

        public async Task<IEnumerable<PlannedPaymentListViewModel>> GetAllPaymentsAsync(int id)
        {
            var model = await repository.AllReadOnly<Payment>()
                .Where(d => d.IsDeleted == false && d.OperationTypeId == (int)OperationType.Payment && d.Debt.Id == id)  
                .Include(d => d.Debt)
                .ThenInclude(d => d.Currency)

                .Select(d => new PlannedPaymentListViewModel
                {
                    
                    PaymentId = d.Id,
                    PaymentDate = d.PaymentDate.ToString(ValidationConstants.DateFormat),
                    PaymentAmount = d.PaymentAmount,
                    InterestRate = d.InterestRate,
                    InterestAmount = d.InterestAmount,
                    OperateTaxAmount = d.OperateTaxAmount,
                    IsDebtFinished = d.Debt.IsFinished

                }).ToListAsync();


            return model;

        }
        public async Task<Payment> GetPaymentEntityByIdAsync(int id)
        {
            return await repository.GetByIdAsync<Payment>(id);


        }
        public async Task<Payment> GetPlannedPaymentInfoByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync<Payment>(id);
            return entity;
        }

        public async Task<List<PlannedPaymentDateViewModel>> GetAllPlannedPaymentDatesAsync(int debtId) 
        {
            return await repository.AllReadOnly<Payment>()
                .Where(d => d.OperationTypeId == (int)OperationType.PlannedPayment && d.DebtId == debtId)

                .Select(c => new PlannedPaymentDateViewModel
                {
                    Id = c.Id,
                    PlannedDate = c.PaymentDate.ToString(ValidationConstants.DateFormat)
                }).ToListAsync();
        }


        public async Task AddRealAsync(AddPaymentViewModel model, string userId, int municipalityId, DateTime datePayment, int paymentParentId)
        {
            Payment payment = new Payment
            {

                DebtId = model.DebtId,
                PaymentParentId = paymentParentId,
                PaymentDate = datePayment,
                PaymentAmount = model.PaymentAmount,
                InterestRate = model.InterestRate,
                InterestAmount = model.InterestAmount,
                OperateTaxAmount = model.OperateTaxAmount,
                OperationTypeId = (int)OperationType. Payment,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(payment);
            await repository.SaveChangesAsync();

        }



    }
}
