using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures; 
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities; 
using MunicipalityDebtsSystem.Core.Services; 
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Test;
using MunicipalityDebtsSystem.Core.Models.Cover;

namespace MunicipalityDebtsSystem.Test
{
    [TestFixture]
    public class CoverServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private CoverService _coverService; 

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _coverService = new CoverService(_mockRepository.Object);
        }

        [Test]
        public async Task GetAllCoversAsync_ReturnsAllCovers()
        {
            
            var coverTypes = new List<CoverType>
            {
                new CoverType { Id = 1, Name = "Парични средства" },
                new CoverType { Id = 2, Name = "Непарични средства" }
            };

            var mockCoverTypes = new TestAsyncEnumerable<CoverType>(coverTypes.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<CoverType>()).Returns(mockCoverTypes);
                        
            var results = await _coverService.GetAllCoversAsync();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Парични средства", results[0].Name);
            Assert.AreEqual("Непарични средства", results[1].Name);
        }

        [Test]
        public async Task AddCoverAsync_CallsAddAndSaveChanges_WithCorrectData()
        {
           
            var model = new AddCoverViewModel
            {
                DebtId = 1,
                CoverTypeId = 2,
                CoverAmount = 1000m,
                CoverDescription = "Обезпечение"
            };

            string userId = "user123";
            int municipalityId = 101;
                       
            await _coverService.AddCoverAsync(model, userId, municipalityId);
                        
            _mockRepository.Verify(r => r.AddAsync(It.Is<Cover>(c =>
                c.DebtId == model.DebtId &&
                c.CoverTypeId == model.CoverTypeId &&
                c.CoverAmount == model.CoverAmount &&
                c.CoverDescription == model.CoverDescription &&
                c.MunicipalityId == municipalityId &&
                c.UserCreated == userId &&
                c.DateCreated.Date == DateTime.Now.Date)), Times.Once());

            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task RemoveCover_CallsDeleteAndSaveChanges_WithCorrectId()
        {
            
            int coverId = 1;

            await _coverService.RemoveCover(coverId);

            _mockRepository.Verify(repo => repo.DeleteAsync<Cover>(coverId), Times.Once(),
                "The DeleteAsync method should be called once with the correct ID.");

            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once(),
                "The SaveChangesAsync method should be called once to commit the changes.");
        }

        [Test]
        public async Task GetCoverEntityByIdAsync_ReturnsCover_WhenCoverExists()
        {
            
            int coverId = 1;
            var expectedCover = new Cover { Id = coverId, CoverDescription = "Обезпечение" };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Cover>(coverId)).ReturnsAsync(expectedCover);
                        
            var result = await _coverService.GetCoverEntityByIdAsync(coverId);
                        
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCover, result);
        }

        [Test]
        public async Task GetCoverEntityByIdAsync_ReturnsNull_WhenCoverDoesNotExist()
        {
            
            int coverId = 1000; 

            _mockRepository.Setup(repo => repo.GetByIdAsync<Cover>(coverId)).ReturnsAsync((Cover)null);

            var result = await _coverService.GetCoverEntityByIdAsync(coverId);

            Assert.IsNull(result);
        }
    }
}