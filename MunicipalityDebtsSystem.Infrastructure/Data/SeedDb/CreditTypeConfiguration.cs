using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
    {
        public void Configure(EntityTypeBuilder<CreditType> builder)
        {
            var data = new SeedData();
            var arr = data.creditTypeArr;
            builder.HasData(arr);
           
        }
    }
}
