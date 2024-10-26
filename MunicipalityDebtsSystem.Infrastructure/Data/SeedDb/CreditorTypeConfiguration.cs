using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;


namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class CreditorTypeConfiguration : IEntityTypeConfiguration<CreditorType>
    {
        public void Configure(EntityTypeBuilder<CreditorType> builder)
        {
            //var data = new SeedData();
            //builder.HasData(new CreditorType[] =  );
        }
    }
}
