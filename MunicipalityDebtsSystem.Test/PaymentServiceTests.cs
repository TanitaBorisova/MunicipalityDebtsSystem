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


    [TestFixture]
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
                        
            await _paymentService.AddPlannedPaymentAsync(model, userId, municipalityId, paymentDate);
                        
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
            
            int paymentId = 10;
                        
            await _paymentService.RemovePayment(paymentId);
                        
            _mockRepository.Verify(repo => repo.DeleteAsync<Payment>(paymentId), Times.Once());
        }

        [Test]
        public async Task RemovePayment_CallsSaveChangesAsync()
        {
            
            int paymentId = 10;
                        
            await _paymentService.RemovePayment(paymentId);
                        
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task GetPaymentEntityByIdAsync_ReturnsCorrectPayment_WhenPaymentExists()
        {
           
            int paymentId = 1;
            var expectedPayment = new Payment { Id = paymentId, PaymentAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync(expectedPayment);
                        
            var result = await _paymentService.GetPaymentEntityByIdAsync(paymentId);
                        
            Assert.That(result, Is.EqualTo(expectedPayment));
            Assert.That(result.Id, Is.EqualTo(paymentId));
        }

        [Test]
        public async Task GetPaymentEntityByIdAsync_ReturnsNull_WhenPaymentDoesNotExist()
        {
            
            int paymentId = 99; 
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync((Payment)null);
                        
            var result = await _paymentService.GetPaymentEntityByIdAsync(paymentId);
                        
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AddRealAsync_CreatesAndSavesPaymentCorrectly()
        {
            
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
                       
            await _paymentService.AddRealAsync(model, userId, municipalityId, paymentDate, paymentParentId);

            
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

        [Test]
        public async Task PlannedPaymentHasChildsAsync_ReturnsTrue_WhenChildPaymentsExist()
        {
            
            int parentId = 1;
            var payments = new List<Payment>
            {
                new Payment { PaymentParentId = parentId }
            };

            var mockPayments = new TestAsyncEnumerable<Payment>(payments.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<Payment>()).Returns(mockPayments);
                        
            bool hasChildren = await _paymentService.PlannedPaymentHasChildsAsync(parentId);
                        
            Assert.IsTrue(hasChildren);
        }

        [Test]
        public async Task PlannedPaymentHasChildsAsync_ReturnsFalse_WhenNoChildPaymentsExist()
        {
            
            int parentId = 1;
            var payments = new List<Payment>();  

            var mockPayments = new TestAsyncEnumerable<Payment>(payments.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<Payment>()).Returns(mockPayments);
                        
            bool hasChildren = await _paymentService.PlannedPaymentHasChildsAsync(parentId);
                        
            Assert.IsFalse(hasChildren);
        }

        [Test]
        public async Task GetPlannedPaymentInfoByIdAsync_ReturnsPayment_WhenPaymentExists()
        {
            
            int paymentId = 1;
            var expectedPayment = new Payment { Id = paymentId, PaymentAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync(expectedPayment);
                        
            var result = await _paymentService.GetPlannedPaymentInfoByIdAsync(paymentId);
                        
            Assert.That(result, Is.EqualTo(expectedPayment));
            Assert.That(result.Id, Is.EqualTo(paymentId));
        }

        [Test]
        public async Task GetPlannedPaymentInfoByIdAsync_ReturnsNull_WhenPaymentDoesNotExist()
        {
            
            int paymentId = 1000; 
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(paymentId)).ReturnsAsync((Payment)null);
                        
            var result = await _paymentService.GetPlannedPaymentInfoByIdAsync(paymentId);
                        
            Assert.IsNull(result);
        }



        [Test]
        public async Task GetPaymentByIdAsync_UsesRepository_Correctly()
        {
            
            var expectedPayment = new Payment { Id = 1, PaymentAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Payment>(1)).ReturnsAsync(expectedPayment);
                       
            var result = await _paymentService.GetPaymentEntityByIdAsync(1);
                        
            Assert.AreEqual(expectedPayment, result);
            _mockRepository.Verify(repo => repo.GetByIdAsync<Payment>(1), Times.Once);
        }

    }
}
