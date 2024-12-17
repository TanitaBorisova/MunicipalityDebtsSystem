using Moq;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Core.Models.Draw;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using MunicipalityDebtsSystem.Core.Enums;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;


namespace MunicipalityDebtsSystem.Test
{
    [TestFixture]
    public class DrawServiceTest
    {
        private Mock<IRepository> _mockRepository;
        private DrawService _drawService;  

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _drawService = new DrawService(_mockRepository.Object);
        }

        [Test]
        public async Task AddPlannedAsync_CreatesAndSavesDrawCorrectly()
        {
           
            var model = new AddPlannedDrawViewModel
            {
                DebtId = 1,
                DrawAmount = 100.00m,

            };
            string userId = "user123";
            int municipalityId = 101;
            DateTime drawDate = new DateTime(2023, 12, 25);

            await _drawService.AddPlannedAsync(model, userId, municipalityId, drawDate);

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


        [Test]
        public async Task AddRealAsync_CreatesAndSavesDrawCorrectly()
        {
            
            var model = new AddDrawViewModel
            {
                DebtId = 1,
                DrawAmount = 100.00m,

            };
            string userId = "userMun";
            int municipalityId = 101;
            DateTime drawDate = new DateTime(2023, 12, 25);
            int drawParentId = 50;
                        
            await _drawService.AddRealAsync(model, userId, municipalityId, drawDate, drawParentId);
                        
            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Draw>(p =>
                p.DebtId == model.DebtId &&
                p.DrawParentId == drawParentId &&
                p.DrawDate == drawDate &&
                p.DrawAmount == model.DrawAmount &&
                p.OperationTypeId == 3 &&
                p.MunicipalityId == municipalityId &&
                p.UserCreated == userId

            )), Times.Once);

        }

        [Test]
        public async Task GetPlannedDrawInfoByIdAsync_ReturnsDraw_WhenDrawExists()
        {
            
            int drawId = 1;
            var expectedDraw = new Draw { Id = drawId, DrawAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Draw>(drawId)).ReturnsAsync(expectedDraw);
                        
            var result = await _drawService.GetPlannedDrawInfoByIdAsync(drawId);
                        
            Assert.That(result, Is.EqualTo(expectedDraw));
            _mockRepository.Verify(repo => repo.GetByIdAsync<Draw>(drawId), Times.Once);
        }

        [Test]
        public async Task GetPlannedDrawInfoByIdAsync_ReturnsNull_WhenDrawDoesNotExist()
        {
            
            int drawId = 2;
            _mockRepository.Setup(repo => repo.GetByIdAsync<Draw>(drawId)).ReturnsAsync((Draw)null);
                        
            var result = await _drawService.GetPlannedDrawInfoByIdAsync(drawId);
                        
            Assert.That(result, Is.Null);
            _mockRepository.Verify(repo => repo.GetByIdAsync<Draw>(drawId), Times.Once);
        }

        [Test]
        public async Task GetDrawEntityByIdAsync_ReturnsDraw_WhenDrawExists()
        {
            
            int drawId = 1;
            var expectedDraw = new Draw { Id = drawId, DrawAmount = 100.00m };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Draw>(drawId)).ReturnsAsync(expectedDraw);
                        
            var result = await _drawService.GetDrawEntityByIdAsync(drawId);
                        
            Assert.That(result, Is.EqualTo(expectedDraw));
            _mockRepository.Verify(repo => repo.GetByIdAsync<Draw>(drawId), Times.Once);
        }

        [Test]
        public async Task GetDrawEntityByIdAsync_ReturnsNull_WhenDrawDoesNotExist()
        {
            
            int drawId = 2;
            _mockRepository.Setup(repo => repo.GetByIdAsync<Draw>(drawId)).ReturnsAsync((Draw)null);
                        
            var result = await _drawService.GetDrawEntityByIdAsync(drawId);
                        
            Assert.That(result, Is.Null);
            _mockRepository.Verify(repo => repo.GetByIdAsync<Draw>(drawId), Times.Once);
        }
        [Test]
        public async Task PlannedDrawHasChildsAsync_ReturnsTrue_WhenChildDrawsExist()
        {
            
            int parentId = 1;
            var draws = new List<Draw>
            {
                new Draw { Id = 1, DrawParentId = parentId },
                new Draw { Id = 2, DrawParentId = parentId }
            };

            var mockSet = new TestAsyncEnumerable<Draw>(draws.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<Draw>()).Returns(mockSet);
                        
            bool result = await _drawService.PlannedDrawHasChildsAsync(parentId);
                        
            Assert.IsTrue(result);
        }

        [Test]
        public async Task PlannedDrawHasChildsAsync_ReturnsFalse_WhenNoChildDrawsExist()
        {
            
            int parentId = 1;

            var draws = new List<Draw>
            {
                new Draw { Id = 1, DrawParentId = 2 },
                new Draw { Id = 2, DrawParentId = 3 }
            };

            var mockSet = new TestAsyncEnumerable<Draw>(draws.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<Draw>()).Returns(mockSet);
                        
            bool result = await _drawService.PlannedDrawHasChildsAsync(parentId);
                        
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveDraw_CallsDeleteAsyncWithCorrectId()
        {
            
            int drawId = 1;
                        
            await _drawService.RemoveDraw(drawId);
                        
            _mockRepository.Verify(repo => repo.DeleteAsync<Draw>(drawId), Times.Once());
        }

        [Test]
        public async Task RemoveDraw_CallsSaveChangesAsync()
        {
            
            int drawId = 1;
                       
            await _drawService.RemoveDraw(drawId);
                        
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task GetAllDrawsAsync_ReturnsCorrectData()
        {
            
            var draws = new List<DrawListViewModel>
            {
                new DrawListViewModel
                {
                    DrawId = 15,
                    DrawDate = DateTime.Now.ToString(),
                    DrawAmount = 200,
                    DrawParentId = 5,
                    DrawParentAmount = 250,
                    DrawParentDate = DateTime.Now.AddDays(-1).ToString(),
                    IsDebtFinished = false
                }
            };

            var mockSet = new TestAsyncEnumerable<DrawListViewModel>(draws.AsQueryable());
            _mockRepository.Setup(r => r.AllReadOnly<DrawListViewModel>()).Returns(mockSet);
                        
            var results = await _drawService.GetAllDrawsAsync(1);
                        
            Assert.IsNotNull(results, "Results should not be null");
            Assert.AreEqual(1, results.Count(), "Should return exactly one draw");
            var result = results.First();
            Assert.IsNotNull(result, "Resulting draw should not be null");
            Assert.AreEqual(100, result.DrawAmount, "Draw amount should be 100");
        }
    }
}
