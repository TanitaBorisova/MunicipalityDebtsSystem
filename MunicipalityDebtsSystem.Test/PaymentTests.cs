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
    using MunicipalityDebtsSystem.Core.Services;
    using MunicipalityDebtsSystem;
    using MunicipalityDebtsSystem.Infrastructure.Data;
    using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;

    [TestFixture]
    public class PaymentTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions; 

        [SetUp]
        public void Setup()
        {
            
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"InMemoryDbForTesting{TestContext.CurrentContext.Test.ID}")
                .Options;

            
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                context.Payments.Add(new Payment { Id = 1, DebtId = 1, IsDeleted = false, OperationTypeId = 2, PaymentDate = System.DateTime.Now, PaymentAmount = 100.00m, InterestRate = 1.5m, InterestAmount = 1.5m, OperateTaxAmount = 0.5m, Debt = new Debt { Id = 1, IsFinished = false } });
                context.Payments.Add(new Payment { Id = 2, DebtId = 1, IsDeleted = true, OperationTypeId = 2, PaymentDate = System.DateTime.Now, PaymentAmount = 200.00m, InterestRate = 2.5m, InterestAmount = 2.5m, OperateTaxAmount = 0.75m, Debt = new Debt { Id = 1, IsFinished = false } });
                context.SaveChanges();
            }
        }

       

        [TearDown]
        public void CleanUp()
        {
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
            }
        }
    }

}
