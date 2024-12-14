using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using OperationType = MunicipalityDebtsSystem.Core.Enums.OperationType;
using System.Text.Json.Nodes;

namespace MunicipalityDebtsSystem.Core.Services
{
    public class DebtService : IDebtService
    {
        private readonly IRepository repository;
        //private readonly ApplicationDbContext context;

        public DebtService(IRepository _repository)
        {
            repository = _repository;
            //context = _context;
        }

        public async Task AddAsync(AddDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealFinish)
        {
            Debt debt = new Debt
            {
                DebtNumber = model.DebtNumber,
                DebtParentId = model.DebtParentId,
                ResolutionNumber = model.ResolutionNumber,
                DateBook = dateBook,
                DateNegotiate = dateBook,
                DateContractFinish = dateContractFinish,
                DateRealFinish = dateRealFinish,
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


        public async Task EditAsync(EditDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealFinish)
        {

            var entity = await repository.GetByIdAsync<Debt>(model.DebtId); //GetEntityDebtById(model.DebtId);

            //DebtId = model.DebtId,
            //DebtParentId = model.DebtParentId,
            entity.DebtNumber = model.DebtNumber;
            entity.ResolutionNumber = model.ResolutionNumber;
            entity.DateBook = dateBook;
            //DateNegotiate = model.DateBook,
            entity.DateContractFinish = dateContractFinish;
            entity.DateRealFinish = dateRealFinish;
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
            var entity = await repository.GetByIdAsync<Debt>(id);
            return entity;
        }

        public async Task<CreditorType> GetEntityCreditorTypeById(int id)
        {
            var entity = await repository.GetByIdAsync<CreditorType>(id);
            return entity;
            //var entity = await repository.All<CreditorType>()
            //    .FirstOrDefaultAsync(d => d.Id == id);
            //return entity;
        }
        public async Task<CreditType> GetEntityCreditTypeById(int id)
        {
            var entity = await repository.GetByIdAsync<CreditType>(id);
            return entity;
            //var entity = await repository.All<CreditType>()
            //    .FirstOrDefaultAsync(d => d.Id == id);
            //return entity;
        }
        public async Task<DebtType> GetEntityDebtTermTypeById(int id)
        {
            var entity = await repository.GetByIdAsync<DebtType>(id);
            return entity;
            //var entity = await repository.All<DebtType>()
            //    .FirstOrDefaultAsync(d => d.Id == id);
            //return entity;
        }
        public async Task<DebtPurposeType> GetEntityDebtPurposeTypeById(int id)
        {
            var entity = await repository.GetByIdAsync<DebtPurposeType>(id);
            return entity;
            //var entity = await repository.All<DebtPurposeType>()
            //    .FirstOrDefaultAsync(d => d.Id == id);
            //return entity;
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
                    Id = d.Id,
                    DebtNumber = d.DebtNumber,
                    ResolutionNumber = d.ResolutionNumber,
                    DateBook = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DateContractFinish = d.DateContractFinish.ToString(ValidationConstants.DateFormat),
                    DateRealFinish = d.DateRealFinish.ToString(ValidationConstants.DateFormat),
                    CurrencyName = d.Currency.CurrencyCode,
                    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(),
                    DebtAmountLocalCcy = d.DebtAmountLocalCcy.ToString(),  //ValidationConstants.CurrencyFormat
                    CreditTypeName = d.CreditType.Name.ToString(),  //Include 
                    CreditorTypeName = d.CreditorType.Name.ToString(),
                    DebtTermTypeName = d.DebtType.Name.ToString(),
                    DebtPurposeTypeName = d.DebtPurposeType.Name.ToString(),
                    InterestTypeName = d.InterestType.Name.ToString(),
                    InterestRate = d.InterestRate.ToString(),
                    MunicipalityName = d.Municipality.Name.ToString(),
                    MunicipalityCode = d.Municipality.MunicipalCode.ToString(),
                    UserCreated = d.UserCreated,
                    DateCreated = d.DateCreated.ToString(ValidationConstants.DateFormat)
                }).FirstOrDefaultAsync();


            return model;
        }

        public async Task<IEnumerable<DebtListViewModel>> GetAllDebtAsync(int municipalityId)
        {
            var model = await repository.AllReadOnly<Debt>()
                .Where(d => d.IsDeleted == false && d.MunicipalityId == municipalityId)
                .Include(d => d.Currency)
                .Include(d => d.CreditStatusType)
                .Select(d => new DebtListViewModel
                {
                    Id = d.Id,
                    //DebtParentId = d.DebtParentId,
                    DebtParentNumber = d.ParentDebt.DebtNumber,
                    DebtNumber = d.DebtNumber,
                    ResolutionNumber = d.ResolutionNumber,
                    DateBook = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DateContractFinish = d.DateContractFinish.ToString(ValidationConstants.DateFormat),

                    CurrencyName = d.Currency.CurrencyCode,
                    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(),

                    MunicipalityName = d.Municipality.Name,
                    MunicipalityCode = d.Municipality.MunicipalCode,
                    StatusName = d.CreditStatusType.Name,

                }).ToListAsync();


            return model;

        }

        public async Task<IEnumerable<DebtListViewModel>> GetAllDebtAdminAsync()
        {
            var model = await repository.AllReadOnly<Debt>()
                .Where(d => d.IsDeleted == false )
                .Include(d => d.Currency)
                .Include(d => d.CreditStatusType)
                .Select(d => new DebtListViewModel
                {
                    Id = d.Id,
                    //DebtParentId = d.DebtParentId,
                    DebtParentNumber = d.ParentDebt.DebtNumber,
                    DebtNumber = d.DebtNumber,
                    ResolutionNumber = d.ResolutionNumber,
                    DateBook = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DateContractFinish = d.DateContractFinish.ToString(ValidationConstants.DateFormat),

                    CurrencyName = d.Currency.CurrencyCode,
                    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(),

                    MunicipalityName = d.Municipality.Name,
                    MunicipalityCode = d.Municipality.MunicipalCode,
                    StatusName = d.CreditStatusType.Name,

                }).ToListAsync();


            return model;

        }
        public async Task<(List<DebtListViewModel> Debts, int TotalRecords, int FilteredRecords)> GetDebtsWithPagingAsync(int pageIndex, int pageSize, string searchValue)
        //public async Task<(List<DebtListViewModel> Debts, int TotalRecords, int FilteredRecords)> GetDebtsWithPagingAsync(int pageIndex, int pageSize)
        {
            // Query to get debts from the database, applying optional filters and pagination
            var query = repository.AllReadOnly<Debt>()
                .Where(d => d.IsDeleted == false)
                .Include(d => d.Currency)
                .Include(d => d.CreditType)
                .Include(d => d.CreditorType)
                .Include(d => d.DebtType)
                .Include(d => d.DebtPurposeType)
                .Include(d => d.InterestType)
                .Include(d => d.CreditStatusType)

                .Select(d => new DebtListViewModel
                {
                    Id = d.Id,
                    //DebtParentId = d.DebtParentId,
                    DebtParentNumber = d.ParentDebt.DebtNumber ?? "няма",
                    DebtNumber = d.DebtNumber,
                    ResolutionNumber = d.ResolutionNumber,
                    DateBook = d.DateBook.ToString(ValidationConstants.DateFormat),
                    DateContractFinish = d.DateContractFinish.ToString(ValidationConstants.DateFormat),

                    CurrencyName = d.Currency.CurrencyCode,
                    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(),

                    MunicipalityName = d.Municipality.Name.ToString(),
                    MunicipalityCode = d.Municipality.MunicipalCode.ToString(),
                    StatusName = d.CreditStatusType.Name.ToString(),

                })
                //.Where(d => searchValue != string.Empty ?  d.DebtNumber.Contains(searchValue) )
                //.Where(x => (searchValue != null ? (x.DateSent != null && x.DateSent.Value.Date <= dateSendTo) : (x.Id == x.Id)))
               // .Where(x => (searchValue != null ? (x.DebtNumber.Contains(searchValue)) : (x.Id == x.Id)))
                .OrderBy(d => d.Id)
                .AsQueryable();

            //|| d.ResolutionNumber.Contains(searchValue) || d.MunicipalityName.Contains(searchValue) || d.MunicipalityCode.Contains(searchValue) || d.CurrencyName.Contains(searchValue) || d.DebtAmountOriginalCcy.Contains(searchValue) || d.DebtAmountOriginalCcy.Contains(searchValue)

          if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(d => d.DebtNumber.Contains(searchValue)|| d.DebtParentNumber.Contains(searchValue) || d.MunicipalityName.Contains(searchValue) || d.ResolutionNumber.Contains(searchValue) || d.MunicipalityName.Contains(searchValue) || d.MunicipalityCode.Contains(searchValue) || d.CurrencyName.Contains(searchValue) || d.DebtAmountOriginalCcy.Contains(searchValue) || d.DebtAmountOriginalCcy.Contains(searchValue)).AsQueryable();
            }

            //// Apply sorting (optional, if needed)
            //query = query.OrderBy(d => d.DebtNumber); // Or apply sorting logic based on your requirements
            var p = query;
            // Fetch the data with pagination
            var debts = await query
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
                //.Select(d => new DebtListViewModel
                //{
                //    DebtId = d.DebtId,
                //    DebtNumber = d.DebtNumber,
                //    DebtParentNumber = d.DebtParentNumber,
                //    ResolutionNumber = d.ResolutionNumber,
                //    DateBook = d.DateBook.ToString("yyyy-MM-dd"),
                //    DateContractFinish = d.DateContractFinish.ToString("yyyy-MM-dd"),
                //    DebtAmountOriginalCcy = d.DebtAmountOriginalCcy.ToString(),
                //    CurrencyName = d.Currency.CurrencyCode,
                //    MunicipalityCode = d.MunicipalityCode,
                //    MunicipalityName = d.MunicipalityName,
                //    StatusName = d.StatusName
                //}).ToListAsync();

            // Get the total record count (without filtering)
            var totalRecords = await query.CountAsync();

            // Get the filtered record count (after applying search filter)
            var filteredRecords = query.Count();

            return (debts, totalRecords, filteredRecords);
        }
        public async Task DeleteDebt(Debt debt)
        {
            debt.IsDeleted = true;
            await repository.SaveChangesAsync();
        }

        public async Task<bool> DebtHasRealDrawsOrPaymentAsync(int id)
        {

            bool hasChildDraws = await repository.AllReadOnly<Draw>()
                   .AnyAsync(d => d.DebtId == id && d.OperationTypeId == (int)OperationType.Draw);

            bool hasChildPayments = await repository.AllReadOnly<Payment>()
                   .AnyAsync(d => d.DebtId == id && d.OperationTypeId == (int)OperationType.Payment);

            bool hasChilds = hasChildDraws || hasChildPayments; 
            return hasChildDraws;
        }


        public async Task NegotiateAsync(NegotiateDebtViewModel model, string userId, int municipalityId, DateTime dateBook, DateTime dateContractFinish, DateTime dateRealContractFinish)
        {
            Debt debt = new Debt
            {
                DebtParentId = model.DebtParentId,
                DebtNumber = model.DebtNumber,
                ResolutionNumber = model.ResolutionNumber,
                DateBook = dateBook,
                DateNegotiate = dateBook,
                DateContractFinish = dateContractFinish,
                DateRealFinish = dateRealContractFinish,
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
                DateCreated = DateTime.Now,
                CreditStatusId = 5

            };

            //some changes to the parent debt
            var parentEntity = await GetEntityDebtById(model.DebtParentId);
            parentEntity.DateRealFinish = dateBook;
            parentEntity.CreditStatusId = 4;//enum to DO
            parentEntity.UserModified = userId; 
            parentEntity.DateModified = DateTime.Now;
            parentEntity.IsNegotiated = true;


            await repository.AddAsync(debt);
            await repository.SaveChangesAsync();

        }

        //public async Task<DebtPartialInfoViewModel> GetDebtInfoForPartial()
        //{
        ////    return await repository.AllReadOnly<Currency>()

        ////        .Select(c => new CurrencyViewModel
        ////        {
        ////            Id = c.Id,
        ////            Name = c.Name
        ////        }).ToListAsync();
        //}

        public async Task<decimal> ReturnSumOfOperationType(int operType, int debtId)
        {
            decimal result;
            switch (operType)
            {
                case 1:
                    result = await repository.AllReadOnly<Payment>()
                         .Where(p => p.DebtId == debtId && p.IsDeleted == false && p.OperationTypeId == operType)
                          .SumAsync(p => (decimal?)p.PaymentAmount ?? 0);
                    break;
                case 2:
                    result = await repository.AllReadOnly<Payment>()
                           .Where(p => p.DebtId == debtId && p.IsDeleted == false && p.OperationTypeId == operType)
                            .SumAsync(p => (decimal?)p.PaymentAmount ?? 0);
                    break;
                case 3:
                    result = await repository.AllReadOnly<Draw>()
                          .Where(d => d.DebtId == debtId && d.IsDeleted == false && d.OperationTypeId == operType)
                           .SumAsync(d => (decimal?)d.DrawAmount ?? 0);
                    break;
                case 4:
                    result = await repository.AllReadOnly<Draw>()
                          .Where(d => d.DebtId == debtId && d.IsDeleted == false && d.OperationTypeId == operType)
                           .SumAsync(d => (decimal?)d.DrawAmount ?? 0);
                    break;
               
                default:
                    result = 0;
                    break;
            }

            return result;
           
        }
    }
}
