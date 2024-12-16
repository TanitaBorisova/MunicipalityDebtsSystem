using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Core.Services;
using System.Linq;

using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;


namespace MunicipalityDebtsSystem.Test
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MunicipalityDebtsSystem.Core.Contracts;
    using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
    using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
    using NUnit.Framework;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

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
            // Arrange
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

            // Act
            await _debtService.AddAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealFinish);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Debt>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);


        }

        [Test]
        public async Task EditAsync_ShouldUpdateDebtAndSaveChanges()
        {
            // Arrange
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

            // Act
            await _debtService.EditAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealFinish);

            // Assert
            Assert.AreEqual("D124", debt.DebtNumber);
            Assert.AreEqual("R124", debt.ResolutionNumber);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetEntityDebtById_ShouldReturnExactDebtEntity()
        {
            // Arrange: Set up mock data
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

            // Set up the mock to return the expected Debt entity when GetByIdAsync is called
            _mockRepository.Setup(repo => repo.GetByIdAsync<Debt>(debtId)).ReturnsAsync(expectedDebt);

            // Act: Call the method under test
            var result = await _debtService.GetEntityDebtById(debtId);

            // Assert: Verify that the result matches the expected debt
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebt.DebtNumber, result.DebtNumber);
            Assert.AreEqual(expectedDebt.DebtParentId, result.DebtParentId);
            Assert.AreEqual(expectedDebt.ResolutionNumber, result.ResolutionNumber);
            Assert.AreEqual(expectedDebt.DebtAmountOriginalCcy, result.DebtAmountOriginalCcy);
            Assert.AreEqual(expectedDebt.DebtAmountLocalCcy, result.DebtAmountLocalCcy);
            Assert.AreEqual(expectedDebt.IsNegotiated, result.IsNegotiated);
            // Verify that GetByIdAsync was called exactly once with the correct id
            _mockRepository.Verify(repo => repo.GetByIdAsync<Debt>(debtId), Times.Once);
        }
        [Test]
        public async Task DeleteDebt_ShouldSetIsDeletedToTrue_AndCallSaveChangesAsync()
        {
            // Arrange
            var debt = new Debt
            {
                Id = 1,
                IsDeleted = false // initially not deleted
            };

            // Act
            await _debtService.DeleteDebt(debt);

            // Assert: Verify that IsDeleted was set to true
            //Assert.IsTrue(debt.IsDeleted, "Debt IsDeleted property should be set to true");

            Assert.IsTrue(debt.IsDeleted);

            // Assert: Verify that SaveChangesAsync was called exactly once
            //_mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "SaveChangesAsync should be called once");
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);

        }

        [Test]
        public async Task NegotiateAsync_ShouldCreateNewDebtAndUpdateParentDebt()
        {
            // Arrange
            var model = new NegotiateDebtViewModel
            {
                DebtParentId = 1,  // Parent debt ID
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
                IsNegotiated = false,  // Initially not negotiated
                CreditStatusId = 1,
                DateRealFinish = DateTime.Now,
                UserModified = null,
                DateModified = null
            };

            _mockRepository.Setup(r => r.GetByIdAsync<Debt>(model.DebtParentId)).ReturnsAsync(parentDebt);

            // Act
            await _debtService.NegotiateAsync(model, userId, municipalityId, dateBook, dateContractFinish, dateRealContractFinish);

            // Assert
            // Verify that the parent debt was updated correctly
            Assert.AreEqual(dateBook, parentDebt.DateRealFinish);
            Assert.AreEqual(4, parentDebt.CreditStatusId);
            Assert.AreEqual(userId, parentDebt.UserModified);
            Assert.IsTrue(parentDebt.IsNegotiated, "Parent debt IsNegotiated should be set to true.");

            // Verify that the repository AddAsync method was called for the new debt
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Debt>()), Times.Once, "AddAsync should be called once to add the new debt.");

            // Verify that SaveChangesAsync was called
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "SaveChangesAsync should be called once.");
        }

        [Test]
        public async Task GetEntityCreditorTypeById_ReturnExactCreditorType()
        {
            // Arrange: Set up mock data
            var creditorTypeId = 3;
            var expectedCreditorType = new CreditorType
            {
                Id = creditorTypeId,    
                Name = "Кредитна институция",
                IsDeleted = false
            };

            // Set up the mock to return the expected Debt entity when GetByIdAsync is called
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId)).ReturnsAsync(expectedCreditorType);
            
            // Act: Call the method under test
             var result = await _debtService.GetEntityCreditorTypeById(creditorTypeId);


            // Assert: Verify that the result matches the expected debt
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCreditorType.Id, result.Id);
            Assert.AreEqual(expectedCreditorType.Name, result.Name);
            Assert.AreEqual(expectedCreditorType.IsDeleted, result.IsDeleted);

            // Verify that GetByIdAsync was called exactly once with the correct id
            _mockRepository.Verify(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId), Times.Once);
        }

        [Test]
        public async Task GetEntityCreditTypeById_ReturnExactCreditType()
        {
            // Arrange: Set up mock data
            var creditTypeId = 3;
            var expectedCreditType = new CreditType
            {
                Id = creditTypeId,
                Name = "Търговски кредити",
                IsDeleted = false
            };

            // Set up the mock to return the expected Debt entity when GetByIdAsync is called
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId)).ReturnsAsync(expectedCreditType);

            // Act: Call the method under test
            var result = await _debtService.GetEntityCreditTypeById(creditTypeId);


            // Assert: Verify that the result matches the expected debt
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCreditType.Id, result.Id);
            Assert.AreEqual(expectedCreditType.Name, result.Name);
            Assert.AreEqual(expectedCreditType.IsDeleted, result.IsDeleted);

            // Verify that GetByIdAsync was called exactly once with the correct id
            _mockRepository.Verify(repo => repo.GetByIdAsync<CreditType>(creditTypeId), Times.Once);
        }
        [Test]
        public async Task GetEntityDebtTypeById_ReturnExactDebtType()
        {
            // Arrange: Set up mock data
            var debtTypeId = 1;
            var expectedDebtType = new DebtType
            {
                Id = debtTypeId,
                Name = "Краткосрочен",
                IsDeleted = false
            };

            // Set up the mock to return the expected Debt entity when GetByIdAsync is called
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(debtTypeId)).ReturnsAsync(expectedDebtType);

            // Act: Call the method under test
            var result = await _debtService.GetEntityDebtTermTypeById(debtTypeId);


            // Assert: Verify that the result matches the expected debt
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebtType.Id, result.Id);
            Assert.AreEqual(expectedDebtType.Name, result.Name);
            Assert.AreEqual(expectedDebtType.IsDeleted, result.IsDeleted);

            // Verify that GetByIdAsync was called exactly once with the correct id
            _mockRepository.Verify(repo => repo.GetByIdAsync<DebtType>(debtTypeId), Times.Once);
        }

        [Test]
        public async Task GetEntityDebtPurposeTypeById_ReturnExactDebtPurposeType()
        {
            // Arrange: Set up mock data
            var debtPurposeTypeId = 1;
            var expectedDebtPurposeType = new DebtPurposeType
            {
                Id = debtPurposeTypeId,
                Name = "Инвестиционни проекти",
                IsDeleted = false
            };

            // Set up the mock to return the expected Debt entity when GetByIdAsync is called
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId)).ReturnsAsync(expectedDebtPurposeType);

            // Act: Call the method under test
            var result = await _debtService.GetEntityDebtPurposeTypeById(debtPurposeTypeId);


            // Assert: Verify that the result matches the expected debt
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDebtPurposeType.Id, result.Id);
            Assert.AreEqual(expectedDebtPurposeType.Name, result.Name);
            Assert.AreEqual(expectedDebtPurposeType.IsDeleted, result.IsDeleted);

            // Verify that GetByIdAsync was called exactly once with the correct id
            _mockRepository.Verify(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId), Times.Once);
        }


       
        [Test]
        public async Task GetAllCurrenciesAsync_ReturnsListOfCurrencyViewModels_WhenCurrenciesExist()
        {
            // Arrange: Setup mock data
            var currencies = new List<Currency>
            {
                new Currency { Id = 1, Name = "USD", IsDeleted = false },
                new Currency { Id = 2, Name = "EUR", IsDeleted = false }
            };

            //// Mock repository to return the list of currencies
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
            // Arrange
            int currencyId = 1;
            var mockCurrency = new Currency
            {
                Id = currencyId,
                Name = "USD"
            };

            // Mock the repository to return the currency
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync(mockCurrency);

            // Act
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);

            // Assert
            Assert.IsTrue(result); // The currency exists, so it should return true.
        }

        [Test]
        public async Task CheckCurrencyExistAsync_ReturnsFalse_WhenCurrencyDoesNotExist()
        {
            // Arrange
            int currencyId = 999; // Non-existing currency ID

            // Mock the repository to return null (currency does not exist)
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync((Currency)null);

            // Act
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);

            // Assert
            Assert.IsFalse(result); // The currency doesn't exist, so it should return false.
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsTrue_WhenCurrencyExists()
        {
            // Arrange
            int currencyId = 1;
            var mockCurrency = new Currency
            {
                Id = currencyId,
                Name = "USD"
            };

            // Mock the repository to return the currency
            _mockRepository.Setup(repo => repo.GetByIdAsync<Currency>(currencyId))
                .ReturnsAsync(mockCurrency);

            // Act
            bool result = await _debtService.CheckCurrencyExistAsync(currencyId);

            // Assert
            Assert.IsTrue(result); // The currency exists, so it should return true.
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsTrue_WhenCreditTypeExists()
        {
            // Arrange
            int creditTypeId = 1;
            var creditType = new CreditType { Id = creditTypeId, Name = "Търговски кредити" }; // Sample CreditType

            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId))
                .ReturnsAsync(creditType);  // Mock the repository method to return a valid CreditType

            // Act
            var result = await _debtService.CheckCreditTypeExistAsync(creditTypeId);

            // Assert
            Assert.True(result);  // Assert that the method returns true as the CreditType exists
        }

        [Test]
        public async Task CheckCreditTypeExistAsync_ReturnsFalse_WhenCreditTypeDoesNotExist()
        {
            // Arrange
            int creditTypeId = 999;  // Non-existing CreditType ID

            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditType>(creditTypeId))
                .ReturnsAsync((CreditType)null);  // Mock the repository method to return null

            // Act
            var result = await _debtService.CheckCreditTypeExistAsync(creditTypeId);

            // Assert
            Assert.False(result);  // Assert that the method returns false as the CreditType doesn't exist
        }

        [Test]
        public async Task CheckCreditorTypeExistAsync_ReturnsTrue_WhenCreditorTypeExists()
        {
            // Arrange
            int creditorTypeId = 1;
            var creditorType = new CreditorType
            {
                Id = creditorTypeId,
                Name = "Кредитна институция",
                IsDeleted = false
            };

            // Mock the repository's GetByIdAsync method
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId))
                .ReturnsAsync(creditorType);

            // Act
            var result = await _debtService.CheckCreditorTypeExistAsync(creditorTypeId);

            // Assert
            Assert.IsTrue(result);  // Expecting true since the creditor type exists
        }

        [Test]
        public async Task CheckCreditorTypeExistAsync_ReturnsFalse_WhenCreditorTypeDoesNotExist()
        {
            // Arrange
            int creditorTypeId = 999; // Non-existing creditor type ID

            // Mock the repository's GetByIdAsync method to return null
            _mockRepository.Setup(repo => repo.GetByIdAsync<CreditorType>(creditorTypeId))
                .ReturnsAsync((CreditorType)null);

            // Act
            var result = await _debtService.CheckCreditorTypeExistAsync(creditorTypeId);

            // Assert
            Assert.IsFalse(result);  // Expecting false since the creditor type does not exist
        }

        [Test]
        public async Task CheckDebtTermTypeExistAsync_ReturnsTrue_WhenDebtTermTypeExists()
        {
            // Arrange
            int existingDebtTermTypeId = 1; // This should match an existing DebtTermType ID in the mock.
            var existingDebtTermType = new DebtType
            {
                Id = existingDebtTermTypeId,
                Name = "Краткосрочен" // Example property
            };

            // Mock the repository to return a DebtTermType when requested by ID.
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(existingDebtTermTypeId))
                .ReturnsAsync(existingDebtTermType);

            // Act
            var result = await _debtService.CheckDebtTermTypeExistAsync(existingDebtTermTypeId);

            // Assert
            Assert.IsTrue(result); // We expect it to return true as the DebtTermType exists.
        }

        [Test]
        public async Task CheckDebtTermTypeExistAsync_ReturnsFalse_WhenDebtTermTypeDoesNotExist()
        {
            // Arrange
            int nonExistingDebtTermTypeId = 999; // This ID doesn't exist in the mock.

            // Mock the repository to return null (not found).
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtType>(nonExistingDebtTermTypeId))
                .ReturnsAsync((DebtType)null);

            // Act
            var result = await _debtService.CheckDebtTermTypeExistAsync(nonExistingDebtTermTypeId);

            // Assert
            Assert.IsFalse(result); // We expect it to return false as the DebtTermType does not exist.
        }

        [Test]
        public async Task CheckDebtPurposeTypeExistAsync_ReturnsTrue_WhenDebtPurposeTypeExists()
        {
            // Arrange
            var debtPurposeTypeId = 1;
            var existingDebtPurposeType = new DebtPurposeType { Id = debtPurposeTypeId };

            // Set up the mock to return a DebtPurposeType when GetByIdAsync is called with the specific ID
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId))
                .ReturnsAsync(existingDebtPurposeType);

            // Act
            var result = await _debtService.CheckDebtPurposeTypeExistAsync(debtPurposeTypeId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckDebtPurposeTypeExistAsync_ReturnsFalse_WhenDebtPurposeTypeDoesNotExist()
        {
            // Arrange
            var debtPurposeTypeId = 999; // ID that doesn't exist
            DebtPurposeType nullDebtPurposeType = null;

            // Set up the mock to return null when GetByIdAsync is called with the specific ID
            _mockRepository.Setup(repo => repo.GetByIdAsync<DebtPurposeType>(debtPurposeTypeId))
                .ReturnsAsync(nullDebtPurposeType);

            // Act
            var result = await _debtService.CheckDebtPurposeTypeExistAsync(debtPurposeTypeId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_ReturnsTrue_WhenInterestTypeExists()
        {
            // Arrange
            int interestTypeId = 1;
            var interestType = new InterestType
            {
                Id = interestTypeId,
                Name = "Фиксиран"
            };

            // Mock the repository to return the interest type
            _mockRepository.Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync(interestType);

            // Act
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            // Assert
            Assert.True(result);  // The result should be true since the InterestType exists
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_ReturnsFalse_WhenInterestTypeDoesNotExist()
        {
            // Arrange
            int interestTypeId = 999; // Non-existing ID

            // Mock the repository to return null for non-existing InterestType
            _mockRepository.Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync((InterestType)null);

            // Act
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            // Assert
            Assert.False(result);  // The result should be false since the InterestType does not exist
        }

        //[Test]
        //public async Task GetDebtByIdAsync_ReturnsDetailDebtViewModel_WhenDebtExists()
        //{
        //    // Arrange
        //    int debtId = 1;
        //    var debt = new Debt
        //    {
               
        //        DebtNumber = "123",
        //        DebtParentId = null,
        //        ResolutionNumber = "Re/123",
        //        DateBook = DateTime.Now,
        //        DateNegotiate = DateTime.Now,
        //        DateContractFinish = DateTime.Now.AddYears(1),
        //        DateRealFinish = DateTime.Now.AddYears(1),
        //        CurrencyId = 1,
        //        DebtAmountOriginalCcy = 2000,
        //        DebtAmountLocalCcy = 2000,
        //        CreditTypeId = 1,
        //        CreditorTypeId = 1,
        //        DebtTermTypeId = 1,
        //        DebtPurposeTypeId = 1,
        //        InterestRate = 5.34M,
        //        InterestTypeId = 1,
        //        MunicipalityId = 32,
        //        UserCreated = "userVarna",
        //        DateCreated = DateTime.Now

        //    };

            
        //    _mockRepository.Setup(repo => repo.AllReadOnly<Debt>())
        //        .Returns(new List<Debt> { debt }.AsQueryable());

        //    // Act
        //    var result = await _debtService.GetDebtByIdAsync(debtId);

        //    //// Assert
        //    //Assert.NotNull(result);
        //    //Assert.AreEqual(debtId, result.Id);
        //    //Assert.AreEqual(debt.DebtNumber, result.DebtNumber);
        //    //Assert.AreEqual(debt.ResolutionNumber, result.ResolutionNumber);
        //    //Assert.AreEqual(debt.DateBook.ToString(ValidationConstants.DateFormat), result.DateBook);
        //    //Assert.AreEqual(debt.DateContractFinish.ToString(ValidationConstants.DateFormat), result.DateContractFinish);
        //    //Assert.AreEqual(debt.DateRealFinish.ToString(ValidationConstants.DateFormat), result.DateRealFinish);
        //    //Assert.AreEqual(debt.DebtAmountOriginalCcy.ToString(), result.DebtAmountOriginalCcy);
        //    //Assert.AreEqual(debt.DebtAmountLocalCcy.ToString(), result.DebtAmountLocalCcy);
        //    ////Assert.AreEqual("Loan", result.CreditTypeId);
        //    ////Assert.AreEqual("Bank", result.CreditorTypeId);
        //    ////Assert.AreEqual("Term Loan", result.DebtTermTypeId);
        //    ////Assert.AreEqual("Investment", result.DebtPurposeTypeName);
        //    ////Assert.AreEqual("Fixed", result.InterestTypeName);
        //    ////Assert.AreEqual("Municipality A", result.MunicipalityName);
        //    ////Assert.AreEqual(debt.MunicipalityId, result.MunicipalityId);
        //    ////Assert.AreEqual("123", result.MunicipalityCode);
        //    //Assert.AreEqual(debt.UserCreated, result.UserCreated);
        //    //Assert.AreEqual(debt.DateCreated.ToString(ValidationConstants.DateFormat), result.DateCreated);
        //}

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenInterestTypeExists_ReturnsTrue()
        {
            // Arrange
            var interestTypeId = 1;
            var interestType = new InterestType { Id = interestTypeId, Name = "Test Interest" };

            // Setup the repository to return an interestType when GetByIdAsync is called
            _mockRepository
                .Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync(interestType);

            // Act
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenInterestTypeDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var interestTypeId = 1;

            // Setup the repository to return null when GetByIdAsync is called
            _mockRepository
                .Setup(repo => repo.GetByIdAsync<InterestType>(interestTypeId))
                .ReturnsAsync((InterestType)null);

            // Act
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckInterestTypeExistAsync_WhenIdIsZero_ReturnsFalse()
        {
            // Arrange
            var interestTypeId = 0;

            // Act
            var result = await _debtService.CheckInterestTypeExistAsync(interestTypeId);

            // Assert
            Assert.False(result); // Assumes your method should return false for invalid IDs
        }


        //[Test]
        //public async Task GetAllDebtTermTypesAsync_ReturnsDebtTermTypeViewModelList()
        //{
        //    // Arrange
        //    var debtTypes = new List<DebtType>
        //{
        //    new DebtType { Id = 1, Name = "Краткосрочен" },
        //    new DebtType { Id = 2, Name = "Дългосрочен" }
        //};

        //    var mockDbSet = CreateMockDbSet(debtTypes);

        //    // Setup the mock repository to return the mocked DbSet for DebtType
        //    _mockRepository.Setup(repo => repo.AllReadOnly<DebtType>())
        //        .Returns(mockDbSet.Object);

        //    // Act
        //    var result = await _debtService.GetAllDebtTermTypesAsync();

        //    Assert.That(result, Is.Not.Null);  
        //    Assert.That(result.Count, Is.EqualTo(2)); 
        //    Assert.That(result[0].Name, Is.EqualTo("Краткосрочен")); 
        //    Assert.That(result[1].Name, Is.EqualTo("Дългосрочен"));  


        //}

        //[Test]
        //public async Task GetAllDebtTermTypesAsync_ReturnsEmptyList_WhenNoDebtTypes()
        //{
        //    // Arrange
        //    var debtTypes = new List<DebtType>();  // Empty list, no debt types

        //    var mockDbSet = CreateMockDbSet(debtTypes);

        //    // Setup the mock repository to return the mocked DbSet for DebtType
        //    _mockRepository.Setup(repo => repo.AllReadOnly<DebtType>())
        //        .Returns(mockDbSet.Object);

        //    // Act
        //    var result = await _service.GetAllDebtTermTypesAsync();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Empty(result); // Check if the returned list is empty
        //}

        //[Test]
        //public async Task GetAllDebtTermTypesAsync_ReturnsCorrectViewModels()
        //{
        //    // Arrange
        //    var debtTypes = new List<DebtType>
        //{
        //    new DebtType { Id = 1, Name = "Personal Loan" },
        //    new DebtType { Id = 2, Name = "Mortgage" }
        //};

        //    var mockDbSet = CreateMockDbSet(debtTypes);

        //    // Setup the mock repository to return the mocked DbSet for DebtType
        //    _mockRepository.Setup(repo => repo.AllReadOnly<DebtType>())
        //        .Returns(mockDbSet.Object);

        //    // Act
        //    var result = await _service.GetAllDebtTermTypesAsync();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(2, result.Count);
        //    Assert.Equal(1, result[0].Id);  // Check that Id is correct in the first item
        //    Assert.Equal("Personal Loan", result[0].Name);  // Check that Name is correct
        //}

        // Helper method to create a mock DbSet for DebtType
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





}

}
    
