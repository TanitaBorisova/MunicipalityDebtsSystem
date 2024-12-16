using MunicipalityDebtsSystem.Core.Models.Payment;
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
using MunicipalityDebtsSystem.Core.Enums;

namespace MunicipalityDebtsSystem.Test
{


    //[TestFixture]
    public class PaymentServiceTests
    {

        private Mock<IRepository> _mockRepository;
        private PaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _paymentService = new PaymentService(_mockRepository.Object);
        }

        [Test]
        public async Task AddPlannedPaymentAsync_CreatesPaymentWithCorrectProperties()
        {
            // Arrange
            var model = new AddPlannedPaymentViewModel
            {
                DebtId = 1,
                PaymentAmount = 100.00m,
                InterestAmount = 5.00m,
                InterestRate = 1.25m,
                OperateTaxAmount = 2.50m
            };
            string userId = "user123";
            int municipalityId = 101;
            DateTime paymentDate = new DateTime(2023, 12, 25);

            // Act
            await _paymentService.AddPlannedPaymentAsync(model, userId, municipalityId, paymentDate);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Payment>(p =>
                p.DebtId == model.DebtId &&
                p.PaymentParentId == null &&
                p.PaymentDate == paymentDate &&
                p.PaymentAmount == model.PaymentAmount &&
                p.InterestAmount == model.InterestAmount &&
                p.InterestRate == model.InterestRate &&
                p.OperateTaxAmount == model.OperateTaxAmount &&
                p.OperationTypeId == 2 &&
                p.MunicipalityId == municipalityId &&
                p.UserCreated == userId
            )), Times.Once);
        }


        [Test]
        public async Task RemovePayment_CallsDeleteAsyncWithCorrectId()
        {
            // Arrange
            int paymentId = 10;

            // Act
            await _paymentService.RemovePayment(paymentId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync<Payment>(paymentId), Times.Once());
        }

        [Test]
        public async Task RemovePayment_CallsSaveChangesAsync()
        {
            // Arrange
            int paymentId = 10;

            // Act
            await _paymentService.RemovePayment(paymentId);

            // Assert
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task GetPaymentEntityByIdAsync_ReturnsCorrectPayment_WhenPaymentExists()
        {
            // Arrange
            int paymentId = 1;
            var expectedPayment = new Payment { Id = paymentId, PaymentAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync(expectedPayment);

            // Act
            var result = await _paymentService.GetPaymentEntityByIdAsync(paymentId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPayment));
            Assert.That(result.Id, Is.EqualTo(paymentId));
        }

        [Test]
        public async Task GetPaymentEntityByIdAsync_ReturnsNull_WhenPaymentDoesNotExist()
        {
            // Arrange
            int paymentId = 99; // Assume no payment exists with this ID
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync((Payment)null);

            // Act
            var result = await _paymentService.GetPaymentEntityByIdAsync(paymentId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AddRealAsync_CreatesAndSavesPaymentCorrectly()
        {
            // Arrange
            var model = new AddPaymentViewModel
            {
                DebtId = 1,
                PaymentAmount = 100.00m,
                InterestRate = 1.5m,
                InterestAmount = 2.0m,
                OperateTaxAmount = 0.5m
            };
            string userId = "user123";
            int municipalityId = 10;
            DateTime paymentDate = DateTime.UtcNow;
            int paymentParentId = 99;

            // Act
            await _paymentService.AddRealAsync(model, userId, municipalityId, paymentDate, paymentParentId);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Payment>(p =>
                p.DebtId == model.DebtId &&
                p.PaymentParentId == paymentParentId &&
                p.PaymentDate == paymentDate &&
                p.PaymentAmount == model.PaymentAmount &&
                p.InterestRate == model.InterestRate &&
                p.InterestAmount == model.InterestAmount &&
                p.OperateTaxAmount == model.OperateTaxAmount &&
                p.OperationTypeId == 1 &&
                p.MunicipalityId == municipalityId &&
                p.UserCreated == userId &&
                p.DateCreated.Date == DateTime.UtcNow.Date
            )), Times.Once());

            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once());
        }

    }
}
