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
using MunicipalityDebtsSystem.Core.Models;
using MunicipalityDebtsSystem.Core.Models.Draw;

namespace MunicipalityDebtsSystem.Test
{
    [TestFixture]
    public class DrawServiceTest
    {
        private Mock<IRepository> _mockRepository;
        private DrawService _drawService;  // Assuming the service class is named DrawService

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _drawService = new DrawService(_mockRepository.Object);
        }

        [Test]
        public async Task AddPlannedAsync_CreatesAndSavesDrawCorrectly()
        {
            // Arrange
            var model = new AddPlannedDrawViewModel
            {
                DebtId = 1,
                DrawAmount = 100.00m,
                
            };
            string userId = "user123";
            int municipalityId = 101;
            DateTime drawDate = new DateTime(2023, 12, 25);

            // Act
            await _drawService.AddPlannedAsync(model, userId, municipalityId, drawDate);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Draw>(p =>
                p.DebtId == model.DebtId &&
                p.DrawParentId == null &&
                p.DrawDate == drawDate &&
                p.DrawAmount == model.DrawAmount &&
                p.OperationTypeId == 4 &&
                p.MunicipalityId == municipalityId &&
                p.UserCreated == userId
            )), Times.Once); 
        }

    }
}
