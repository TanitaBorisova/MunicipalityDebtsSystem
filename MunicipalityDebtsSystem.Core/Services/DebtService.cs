﻿using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class DebtService : IDebtService
    {
        private readonly IRepository repository;

        public DebtService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(AddDebtViewModel model, string userId, int municipalityId)
        {
            Debt debt = new Debt
            {
                DebtNumber = model.DebtNumber,
                ResolutionNumber = model.ResolutionNumber,
                DateBook = model.DateBook,
                DateNegotiate = model.DateBook,
                DateContractFinish = model.DateContractFinish,
                DateRealFinish = model.DateRealFinish,
                CurrencyId = model.CurrencyId,
                DebtAmountOriginalCcy = model.DebtAmountOriginalCcy,
                DebtAmountLocalCcy = model.DebtAmountLocalCcy,
                CreditTypeId = model.CreditTypeId,
                CreditorTypeId = model.CreditorTypeId,
                DebtTermTypeId = model.DebtTermTypeId,
                DebtPurposeTypeId = model.DebtPurposeTypeId,
                InterestRate = model.InterestRate,
                InterestTypeId = model.InterestTypeId,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(debt);    
            await repository.SaveChangesAsync();

        }


        public async Task EditAsync(EditDebtViewModel model, string userId, int municipalityId)
        {

            var entity = await GetEntityDebtById(model.DebtId);

            //DebtId = model.DebtId,
            //DebtParentId = model.DebtParentId,
            entity.DebtNumber = model.DebtNumber;
            entity.ResolutionNumber = model.ResolutionNumber;
            entity.DateBook = model.DateBook;
            //DateNegotiate = model.DateBook,
            entity.DateContractFinish = model.DateContractFinish;
            entity.DateRealFinish = model.DateRealFinish;
            entity.CurrencyId = model.CurrencyId;
            entity.DebtAmountOriginalCcy = model.DebtAmountOriginalCcy;
            entity.DebtAmountLocalCcy = model.DebtAmountLocalCcy;
            entity.CreditTypeId = model.CreditTypeId;
            entity.CreditorTypeId = model.CreditorTypeId;
            entity.DebtTermTypeId = model.DebtTermTypeId;
            entity.DebtPurposeTypeId = model.DebtPurposeTypeId;
            entity.InterestRate = model.InterestRate;
            entity.InterestTypeId = model.InterestTypeId;
            entity.MunicipalityId = municipalityId;
            entity.UserModified = userId;
            entity.DateModified = DateTime.Now;

          

            
            await repository.SaveChangesAsync();

        }
        public async Task<Debt> GetEntityDebtById(int id)
        {
            var entity = await repository.All<Debt>()
                //.Include(d => d.Currency)
                //.Include(d => d.CreditorType)
                //.Include(d => d.CreditType)
                //.Include(d => d.DebtType)
                //.Include(d => d.DebtPurposeType)
                //.Include(d => d.InterestType)
                .FirstOrDefaultAsync(d => d.Id == id);
            return entity;
        }

        public async Task<CreditorType> GetEntityCreditorTypeById(int id)
        {
            var entity = await repository.All<CreditorType>()
                .FirstOrDefaultAsync(d => d.Id == id);
            return entity;
        }
        public async Task<CreditType> GetEntityCreditTypeById(int id)
        {
            var entity = await repository.All<CreditType>()
                .FirstOrDefaultAsync(d => d.Id == id);
            return entity;
        }
        public async Task<DebtType> GetEntityDebtTermTypeById(int id)
        {
            var entity = await repository.All<DebtType>()
                .FirstOrDefaultAsync(d => d.Id == id);
            return entity;
        }
        public async Task<DebtPurposeType> GetEntityDebtPurposeTypeById(int id)
        {
            var entity = await repository.All<DebtPurposeType>()
                .FirstOrDefaultAsync(d => d.Id == id);
            return entity;
        }
        public async Task<List<CurrencyViewModel>> GetAllCurrenciesAsync()
        {
            return await repository.AllReadOnly<Currency>()

                .Select(c => new CurrencyViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<CreditorTypeViewModel>> GetAllCreditorTypesAsync()
        {
            return await repository.AllReadOnly<CreditorType>()

                .Select(c => new CreditorTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<CreditTypeViewModel>> GetAllCreditTypesAsync()
        {
            return await repository.AllReadOnly<CreditType>()

                .Select(c => new CreditTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<DebtPurposeTypeViewModel>> GetAllDebtPurposeTypesAsync()
        {
            return await repository.AllReadOnly<DebtPurposeType>()

                .Select(c => new DebtPurposeTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<InterestTypeViewModel>> GetAllInterestTypesAsync()
        {
            return await repository.AllReadOnly<InterestType>()

                .Select(c => new InterestTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<List<DebtTermTypeViewModel>> GetAllDebtTermTypesAsync()
        {
            return await repository.AllReadOnly<DebtType>()

                .Select(c => new DebtTermTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<bool> CheckCurrencyExistAsync(int id)
        {
            bool currencyExist = false;
            var currency = await repository.GetByIdAsync<Currency>(id);

            if (currency != null)
            {
                currencyExist = true;
            }
            return currencyExist;
        }
        public async Task<bool> CheckCreditTypeExistAsync(int id)
        {
            bool creditTypeExist = false;
            var creditType = await repository.GetByIdAsync<CreditType>(id);

            if (creditType != null)
            {
                creditTypeExist = true;
            }
            return creditTypeExist;
        }

        public async Task<bool> CheckCreditorTypeExistAsync(int id)
        {
            bool creditorTypeExist = false;
            var creditorType = await repository.GetByIdAsync<CreditorType>(id);

            if (creditorType != null)
            {
                creditorTypeExist = true;
            }
            return creditorTypeExist;
        }

        public async Task<bool> CheckDebtTermTypeExistAsync(int id)
        {
            bool debtTermTypeExist = false;
            var debtTermType = await repository.GetByIdAsync<DebtType>(id);

            if (debtTermType != null)
            {
                debtTermTypeExist = true;
            }
            return debtTermTypeExist;
        }

        public async Task<bool> CheckDebtPurposeTypeExistAsync(int id)
        {
            bool debtPurposeTypeExist = false;
            var debtPurposeType = await repository.GetByIdAsync<DebtPurposeType>(id);

            if (debtPurposeType != null)
            {
                debtPurposeTypeExist = true;
            }
            return debtPurposeTypeExist;
        }

        public async Task<bool> CheckInterestTypeExistAsync(int id)
        {
            bool interestTypeExist = false;
            var interestType = await repository.GetByIdAsync<InterestType>(id);

            if (interestType != null)
            {
                interestTypeExist = true;
            }
            return interestTypeExist;
        }


        public async Task<DetailDebtViewModel> GetDebtByIdAsync(int id)
        {
            var model = await repository.AllReadOnly<Debt>()
                .Where(d => d.Id == id && d.IsDeleted == false)
                .Include(d => d.Currency)
                .Include(d => d.CreditType)
                .Include(d => d.CreditorType)
                .Include(d => d.DebtType)
                .Include(d => d.DebtPurposeType)
                .Include(d => d.InterestType)
                .Select(d => new DetailDebtViewModel
                {
                    DebtId = d.Id,
                    DebtNumber = d.DebtNumber,
                    ResolutionNumber = d.ResolutionNumber,
                    DateBook = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DateContractFinish = d.DateContractFinish.ToString(ValidationConstants.DateFormat),
                    DateRealFinish = d.DateRealFinish.ToString(ValidationConstants.DateFormat),
                    CurrencyName = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(ValidationConstants.CurrencyFormat),
                    DebtAmountLocalCcy = d.DebtAmountLocalCcy.ToString(ValidationConstants.CurrencyFormat),
                    CreditTypeName = d.CreditType.Name.ToString(),  //Include 
                    CreditorTypeName = d.CreditorType.Name.ToString(),
                    DebtTermTypeName = d.DebtType.Name.ToString(),
                    DebtPurposeTypeName = d.DebtPurposeType.Name.ToString(),
                    InterestTypeName = d.InterestType.Name.ToString(),
                    InterestRate = d.InterestRate.ToString(ValidationConstants.CurrencyFormat),
                    MunicipalityName = d.Municipality.Name.ToString(),
                    MunicipalityCode = d.Municipality.MunicipalCode.ToString(),
                    UserCreated = d.UserCreated,
                    DateCreated = d.DateCreated.ToString(ValidationConstants.DateFormat)
                }).FirstOrDefaultAsync();


            return model;
        }

        public async Task DeleteProduct(Debt debt)
        {
            debt.IsDeleted = true;
            await repository.SaveChangesAsync();
        }

        public Task DeleteDebt(Debt debt)
        {
            throw new NotImplementedException();
        }

        public async Task NegotiateAsync(NegotiateDebtViewModel model, string userId, int municipalityId)
        {
            Debt debt = new Debt
            {
                DebtParentId = model.DebtId,
                DebtNumber = model.DebtNumber,
                ResolutionNumber = model.ResolutionNumber,
                DateBook = model.DateBook,
                DateNegotiate = model.DateBook,
                DateContractFinish = model.DateContractFinish,
                DateRealFinish = model.DateRealFinish,
                CurrencyId = model.CurrencyId,
                DebtAmountOriginalCcy = model.DebtAmountOriginalCcy,
                DebtAmountLocalCcy = model.DebtAmountLocalCcy,
                CreditTypeId = model.CreditTypeId,
                CreditorTypeId = model.CreditTypeId,
                DebtTermTypeId = model.DebtTermTypeId,
                DebtPurposeTypeId = model.DebtPurposeTypeId,
                InterestRate = model.InterestRate,
                InterestTypeId = model.InterestTypeId,
                MunicipalityId = municipalityId,
                UserCreated = userId,
                DateCreated = DateTime.Now

            };

            await repository.AddAsync(debt);
            await repository.SaveChangesAsync();

        }
    }
}