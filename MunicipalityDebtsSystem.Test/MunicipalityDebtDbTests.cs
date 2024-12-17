using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Services;
using System.Linq;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Test
{


    public class DebtServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private DebtService _debtService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _debtService = new DebtService(_mockRepository.Object);
        }

        [Test]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            
            var model = new AddDebtViewModel
            {
                DebtNumber = "123",
                DebtParentId = null,
                ResolutionNumber = "Re/123",
                CurrencyId = 1,
                DebtAmountOriginalCcy = 1000,
                DebtAmountLocalCcy = 1000,
                CreditTypeId = 1,
                CreditorTypeId = 1,
                DebtTermTypeId = 2,
                DebtPurposeTypeId = 1,
                InterestRate = 5,
                InterestTypeId = 1
            };
            var userId = "userBansko";
            var municipalityId = 1;
            var dateBook = DateTime.Now;
            var dateContractFinish = DateTime.Now.AddMonths(12);
            var dateRealFinish = DateTime.Now.AddMonths(12);

            
            await _debtService.AddAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealFinish);

            
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Debt>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);


        }

        [Test]
        public async Task EditAsync_ShouldUpdateDebtAndSaveChanges()
        {
            
            var model = new EditDebtViewModel
            {
                DebtId = 1,
                DebtNumber = "D124",
                ResolutionNumber = "R124",
                CurrencyId = 1,
                DebtAmountOriginalCcy = 1200,
                DebtAmountLocalCcy = 1200,
                CreditTypeId = 1,
                CreditorTypeId = 1,
                DebtTermTypeId = 1,
                DebtPurposeTypeId = 1,
                InterestRate = 6,
                InterestTypeId = 1
            };

            var userId = "userVarna";
            var municipalityId = 32;
            var dateBook = DateTime.Now;
            var dateContractFinish = DateTime.Now.AddMonths(36);
            var dateRealFinish = DateTime.Now.AddMonths(36);

            var debt = new Debt
            {
                DebtNumber = "123",
                ResolutionNumber = "Re/123",
                DebtAmountOriginalCcy = 2000,
                DebtAmountLocalCcy = 2000
            };

            _mockRepository.Setup(repo => repo.GetByIdAsync<Debt>(model.DebtId)).ReturnsAsync(debt);
                        
            await _debtService.EditAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealFinish);
                        
            Assert.AreEqual("D124", debt.DebtNumber);
            Assert.AreEqual("R124", debt.ResolutionNumber);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetEntityDebtById_ShouldReturnExactDebtEntity()
        {
            
            var debtId = 2; 
            var expectedDebt = new Debt
            {
                DebtNumber = "789",
                DebtParentId = 1,
                ResolutionNumber = "Re/789",
                CurrencyId = 1,
                DebtAmountOriginalCcy = 5000,
                DebtAmountLocalCcy = 5000,
                CreditTypeId = 1,
                CreditorTypeId = 1,
                DebtTermTypeId = 1,
                DebtPurposeTypeId = 1,
                InterestRate = 5,
                InterestTypeId = 1,
                IsNegotiated = true
            };

            
            _mockRepository.Setup(repo => repo.GetByIdAsync<Debt>(debtId)).ReturnsAsync(expectedDebt);

            
            var result = await _debtService.GetEntityDebtById(debtId);
                        
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebt.DebtNumber, result.DebtNumber);
            Assert.AreEqual(expectedDebt.DebtParentId, result.DebtParentId);
            Assert.AreEqual(expectedDebt.ResolutionNumber, result.ResolutionNumber);
            Assert.AreEqual(expectedDebt.DebtAmountOriginalCcy, result.DebtAmountOriginalCcy);
            Assert.AreEqual(expectedDebt.DebtAmountLocalCcy, result.DebtAmountLocalCcy);
            Assert.AreEqual(expectedDebt.IsNegotiated, result.IsNegotiated);
          
            _mockRepository.Verify(repo => repo.GetByIdAsync<Debt>(debtId), Times.Once);
        }
        [Test]
        public async Task DeleteDebt_ShouldSetIsDeletedToTrue_AndCallSaveChangesAsync()
        {
            
            var debt = new Debt
            {
                Id = 1,
                IsDeleted = false 
            };

           
            await _debtService.DeleteDebt(debt);
                        
            Assert.IsTrue(debt.IsDeleted);
                        
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);

        }

        [Test]
        public async Task NegotiateAsync_ShouldCreateNewDebtAndUpdateParentDebt()
        {
            
            var model = new NegotiateDebtViewModel
            {
                DebtParentId = 1,  
                DebtNumber = "DN12345",
                ResolutionNumber = "RN12345",
                CurrencyId = 1,
                DebtAmountOriginalCcy = 1000.00M,
                DebtAmountLocalCcy = 2000.00M,
                CreditTypeId = 1,
                CreditorTypeId = 1,
                DebtTermTypeId = 1,
                DebtPurposeTypeId = 1,
                InterestRate = 5.0M,
                InterestTypeId = 1
            };

            var userId = "user123";
            var municipalityId = 100;
            var dateBook = DateTime.Now;
            var dateContractFinish = DateTime.Now.AddMonths(6);
            var dateRealContractFinish = DateTime.Now.AddMonths(12);

            var parentDebt = new Debt
            {
                Id = model.DebtParentId,
                IsNegotiated = false,  
                CreditStatusId = 1,
                DateRealFinish = DateTime.Now,
                UserModified = null,
                DateModified = null
            };

            _mockRepository.Setup(r => r.GetByIdAsync<Debt>(model.DebtParentId)).ReturnsAsync(parentDebt);

            
            await _debtService.NegotiateAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealContractFinish);
                        
            Assert.AreEqual(dateBook, parentDebt.DateRealFinish);
            Assert.AreEqual(4, parentDebt.CreditStatusId);
            Assert.AreEqual(userId, parentDebt.UserModified);
            Assert.IsTrue(parentDebt.IsNegotiated, "Parent debt IsNegotiated should be set to true.");
                        
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Debt>()), Times.Once, "AddAsync should be called once to add the new debt.");
                        
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "SaveChangesAsync should be called once.");
        }

        [Test]
        public async Task GetEntityCreditorTypeById_ReturnExactCreditorType()
        {
            
            var creditorTypeId = 3;
            var expectedCreditorType = new CreditorType
            {
                Id = creditorTypeId,    
                Name = "Кредитна институция",
                IsDeleted = false
            };
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId)).ReturnsAsync(expectedCreditorType);
                       
             var result = await _debtService.GetEntityCreditorTypeById(creditorTypeId);

           
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCreditorType.Id, result.Id);
            Assert.AreEqual(expectedCreditorType.Name, result.Name);
            Assert.AreEqual(expectedCreditorType.IsDeleted, result.IsDeleted);
                        
            _mockRepository.Verify(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId), Times.Once);
        }

        [Test]
        public async Task GetEntityCreditTypeById_ReturnExactCreditType()
        {
           
            var creditTypeId = 3;
            var expectedCreditType = new CreditType
            {
                Id = creditTypeId,
                Name = "Търговски кредити",
                IsDeleted = false
            };

            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId)).ReturnsAsync(expectedCreditType);
                        
            var result = await _debtService.GetEntityCreditTypeById(creditTypeId);
                        
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCreditType.Id, result.Id);
            Assert.AreEqual(expectedCreditType.Name, result.Name);
            Assert.AreEqual(expectedCreditType.IsDeleted, result.IsDeleted);
                        
            _mockRepository.Verify(repo => repo.GetByIdAsync<CreditType>(creditTypeId), Times.Once);
        }
        [Test]
        public async Task GetEntityDebtTypeById_ReturnExactDebtType()
        {
            
            var debtTypeId = 1;
            var expectedDebtType = new DebtType
            {
                Id = debtTypeId,
                Name = "Краткосрочен",
                IsDeleted = false
            };
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(debtTypeId)).ReturnsAsync(expectedDebtType);
                        
            var result = await _debtService.GetEntityDebtTermTypeById(debtTypeId);
                       
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebtType.Id, result.Id);
            Assert.AreEqual(expectedDebtType.Name, result.Name);
            Assert.AreEqual(expectedDebtType.IsDeleted, result.IsDeleted);
                       
            _mockRepository.Verify(repo => repo.GetByIdAsync<DebtType>(debtTypeId), Times.Once);
        }

        [Test]
        public async Task GetEntityDebtPurposeTypeById_ReturnExactDebtPurposeType()
        {
            
            var debtPurposeTypeId = 1;
            var expectedDebtPurposeType = new DebtPurposeType
            {
                Id = debtPurposeTypeId,
                Name = "Инвестиционни проекти",
                IsDeleted = false
            };
                       
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId)).ReturnsAsync(expectedDebtPurposeType);
                        
            var result = await _debtService.GetEntityDebtPurposeTypeById(debtPurposeTypeId);
                        
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebtPurposeType.Id, result.Id);
            Assert.AreEqual(expectedDebtPurposeType.Name, result.Name);
            Assert.AreEqual(expectedDebtPurposeType.IsDeleted, result.IsDeleted);
                       
            _mockRepository.Verify(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId), Times.Once);
        }


       
        [Test]
        public async Task GetAllCurrenciesAsync_ReturnsListOfCurrencyViewModels_WhenCurrenciesExist()
        {
            
            var currencies = new List<Currency>
            {
                new Currency { Id = 1, Name = "USD", IsDeleted = false },
                new Currency { Id = 2, Name = "EUR", IsDeleted = false }
            };

            
            _mockRepository.Setup(repo => repo.AllReadOnly<Currency>())
                           .Returns(currencies.AsQueryable());

            //// Act: Call the service method
          //  var result = await _debtService.GetAllCurrenciesAsync();

            //// Assert: Verify the result is not null and has the correct data
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count);

            //// Check each CurrencyViewModel returned by the method
            //Assert.AreEqual(1, result[0].Id);
            //Assert.AreEqual("USD", result[0].Name);

            //Assert.AreEqual(2, result[1].Id);
            //Assert.AreEqual("EUR", result[1].Name);
        }

        [Test]
        public async Task CheckCurrencyExistAsync_ReturnsTrue_WhenCurrencyExists()
        {
            int currencyId = 1;
            var mockCurrency = new Currency
            {
                Id = currencyId,
                Name = "USD"
            };
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync(mockCurrency);
                        
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);
                        
            Assert.IsTrue(result); 
        }

        [Test]
        public async Task CheckCurrencyExistAsync_ReturnsFalse_WhenCurrencyDoesNotExist()
        {
            
            int currencyId = 1000; 
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync((Currency)null);
                        
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);
                        
            Assert.IsFalse(result); 
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsTrue_WhenCurrencyExists()
        {
            int currencyId = 1;

            var mockCurrency = new Currency
            {
                Id = currencyId,
                Name = "USD"
            };
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync(mockCurrency);
                        
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);
                        
            Assert.IsTrue(result); 
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsTrue_WhenCreditTypeExists()
        {
            
            int creditTypeId = 1;
            var creditType = new CreditType { Id = creditTypeId, Name = "Търговски кредити" }; 

            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId))
                .ReturnsAsync(creditType);  
            
            var result = await _debtService.CheckCreditTypeExistAsync(creditTypeId);

            
            Assert.True(result);  
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsFalse_WhenCreditTypeDoesNotExist()
        {
           
            int creditTypeId =1000; 

            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId))
                .ReturnsAsync((CreditType)null); 
                       
            var result = await _debtService.CheckCreditTypeExistAsync(creditTypeId);
                        
            Assert.False(result);  
        }

        [Test]
        public async Task CheckCreditorTypeExistAsync_ReturnsTrue_WhenCreditorTypeExists()
        {
            
            int creditorTypeId = 1;
            var creditorType = new CreditorType
            {
                Id = creditorTypeId,
                Name = "Кредитна институция",
                IsDeleted = false
            };

            
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId))
                .ReturnsAsync(creditorType);
                        
            var result = await _debtService.CheckCreditorTypeExistAsync(creditorTypeId);
                        
            Assert.IsTrue(result); 
        }

        [Test]
        public async Task CheckCreditorTypeExistAsync_ReturnsFalse_WhenCreditorTypeDoesNotExist()
        {
            
            int creditorTypeId = 1000; 
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId))
                .ReturnsAsync((CreditorType)null);
                        
            var result = await _debtService.CheckCreditorTypeExistAsync(creditorTypeId);
                        
            Assert.IsFalse(result);  
        }

        [Test]
        public async Task CheckDebtTermTypeExistAsync_ReturnsTrue_WhenDebtTermTypeExists()
        {
            
            int existingDebtTermTypeId = 1; 
            var existingDebtTermType = new DebtType
            {
                Id = existingDebtTermTypeId,
                Name = "Краткосрочен" 
            };
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(existingDebtTermTypeId))
                .ReturnsAsync(existingDebtTermType);

            var result = await _debtService.CheckDebtTermTypeExistAsync(existingDebtTermTypeId);
                       
            Assert.IsTrue(result); 
        }

        [Test]
        public async Task CheckDebtTermTypeExistAsync_ReturnsFalse_WhenDebtTermTypeDoesNotExist()
        {
            
            int nonExistingDebtTermTypeId = 1000; 
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(nonExistingDebtTermTypeId))
                .ReturnsAsync((DebtType)null);
                        
            var result = await _debtService.CheckDebtTermTypeExistAsync(nonExistingDebtTermTypeId);
                        
            Assert.IsFalse(result); 
        }

        [Test]
        public async Task CheckDebtPurposeTypeExistAsync_ReturnsTrue_WhenDebtPurposeTypeExists()
        {
            
            var debtPurposeTypeId = 1;
            var existingDebtPurposeType = new DebtPurposeType { Id = debtPurposeTypeId };

            
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId))
                .ReturnsAsync(existingDebtPurposeType);
                       
            var result = await _debtService.CheckDebtPurposeTypeExistAsync(debtPurposeTypeId);
            
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckDebtPurposeTypeExistAsync_ReturnsFalse_WhenDebtPurposeTypeDoesNotExist()
        {
            
            var debtPurposeTypeId = 1000; 
            DebtPurposeType nullDebtPurposeType = null;
                        
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId))
                .ReturnsAsync(nullDebtPurposeType);
                        
            var result = await _debtService.CheckDebtPurposeTypeExistAsync(debtPurposeTypeId);
                        
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_ReturnsTrue_WhenInterestTypeExists()
        {
           
            int interestTypeId = 1;
            var interestType = new InterestType
            {
                Id = interestTypeId,
                Name = "Фиксиран"
            };

            
            _mockRepository.Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync(interestType);
                        
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);
                        
            Assert.True(result);  
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_ReturnsFalse_WhenInterestTypeDoesNotExist()
        {
            
            int interestTypeId = 100; 

            
            _mockRepository.Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync((InterestType)null);

            
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            
            Assert.False(result);  
        }

        

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenInterestTypeExists_ReturnsTrue()
        {
            
            var interestTypeId = 1;
            var interestType = new InterestType { Id = interestTypeId, Name = "Test Interest" };
                        
            _mockRepository
                .Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync(interestType);
                        
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);
                        
            Assert.True(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenInterestTypeDoesNotExist_ReturnsFalse()
        {
            
            var interestTypeId = 1;
                        
            _mockRepository
                .Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync((InterestType)null);
                        
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);
                        
            Assert.False(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenIdIsZero_ReturnsFalse()
        {
           
            var interestTypeId = 0;
                        
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);
                        
            Assert.False(result); 
        }

        
        private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();
            var queryable = data.AsQueryable();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockDbSet;
        }

              
        [Test]
        public async Task GetAllCurrenciesAsync_ReturnsAllCurrencies()
        {
            
            var currencies = new List<Currency>
        {
            new Currency { Id = 1, Name = "Dollar" },
            new Currency { Id = 2, Name = "Euro" }
        };

            var mockCurrencies = new TestAsyncEnumerable<Currency>(currencies.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<Currency>()).Returns(mockCurrencies);
                        
            var results = await _debtService.GetAllCurrenciesAsync();
                        
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Dollar", results[0].Name);
            Assert.AreEqual("Euro", results[1].Name);
        }

        [Test]
        public async Task GetAllCreditorTypesAsync_ReturnsAllCreditorTypes()
        {
            
            var creditorTypes = new List<CreditorType> {
            new CreditorType { Id = 1, Name = "Банка" },
            new CreditorType { Id = 2, Name = "Кредитна институция" }
        };

            var mockCreditorTypes = new TestAsyncEnumerable<CreditorType>(creditorTypes.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<CreditorType>()).Returns(mockCreditorTypes);
                        
            var results = await _debtService.GetAllCreditorTypesAsync();
                        
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Банка", results[0].Name);
            Assert.AreEqual("Кредитна институция", results[1].Name);
        }

       
    }

}
    
