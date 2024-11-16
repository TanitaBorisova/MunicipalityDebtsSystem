using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using MunicipalityDebtsSystem.Infrastructure.Data.SeedDb;
using System.Reflection.Emit;
using System.Xml;
//using MunicipalityDebtsSystem.Areas.Identity.Data;


namespace MunicipalityDebtsSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CreditorType> CreditorsTypes { get; set; } = null!;

        public DbSet<CreditType> CreditsTypes { get; set; } = null!;

        public DbSet<CreditStatusType> CreditStatusTypes { get; set; } = null!;

        public DbSet<DebtType> DebtsTypes { get; set; } = null!;

        public DbSet<DebtPurposeType> DebtPurposeTypes { get; set; } = null!;

        public DbSet<InterestType> InterestsTypes { get; set; } = null!;

        public DbSet<CoverType> CoversTypes { get; set; } = null!;

        public DbSet<Debt> Debts { get; set; } = null!;

        public DbSet<Cover> Covers { get; set; } = null!;

        public DbSet<Draw> Draws { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        public DbSet<MunicipalCenter> MunicipalsCenters { get; set; } = null!;

        public DbSet<Municipality> Municipalities { get; set; } = null!;

        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<CurrencyRate> CurrenciesRates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Debt>()
               .HasOne(e => e.DebtType)
               .WithMany()
               .HasForeignKey(e => e.DebtTermTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Debt>()
              .HasOne(e => e.Municipality)
              .WithMany()
              .HasForeignKey(e => e.MunicipalityId)
            .OnDelete(DeleteBehavior.Restrict);

           
            builder.ApplyConfiguration(new CreditorTypeConfiguration());
            builder.ApplyConfiguration(new CreditTypeConfiguration());
            builder.ApplyConfiguration(new CreditStatusTypeConfiguration());
            builder.ApplyConfiguration(new DebtPurposeTypeConfiguration());
            builder.ApplyConfiguration(new DebtTypeConfiguration());
            builder.ApplyConfiguration(new InterestTypeConfiguration());
            builder.ApplyConfiguration(new CoverTypeConfiguration());
            builder.ApplyConfiguration(new OperationTypeConfiguration());
            builder.ApplyConfiguration(new MunicipalCenterConfiguration());
            builder.ApplyConfiguration(new MunicipalityConfiguration());
            builder.ApplyConfiguration(new CurrencyConfiguration());
            builder.ApplyConfiguration(new CurrencyRateConfiguration());

            base.OnModelCreating(builder);
        }

        
    }
}
