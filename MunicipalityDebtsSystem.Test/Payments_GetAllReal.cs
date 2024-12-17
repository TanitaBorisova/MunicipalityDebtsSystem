using MunicipalityDebtsSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Test
{
    using NUnit.Framework;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using MunicipalityDebtsSystem.Infrastructure; 
    using MunicipalityDebtsSystem.Core.Enums;
    using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
    using MunicipalityDebtsSystem.Core.Services;
    using MunicipalityDebtsSystem.Infrastructure.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class Payments_GetAllReal
    {

        private ApplicationDbContext _context;
        private IRepository _repository;
        private PaymentService _service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _repository = new Repository(_context); // Wrap the DbContext in the Repository
            _service = new PaymentService(_repository); // Pass the IRepository
        }

        //[Test]
        //public async Task GetAllPaymentsAsync_OnlyReturnsActivePayments()
        //{
        //    // Arrange data in _context as needed

        //    // Act
        //    var results = await _service.GetAllPaymentsAsync(1);

        //    // Assert
        //    Assert.That(results, Is.Not.Empty);
        //    // More assertions as needed
        //}



        [TearDown]
        public void CleanUp()
        {
            //// Ensures that the database is deleted after tests to avoid contamination between tests
            //using (var _context = new ApplicationDbContext(_dbContextOptions))
            //{
            //    _context.Database.EnsureDeleted();
            //}
            _context.Dispose();
        }

    }
}
