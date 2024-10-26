using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class InterestTypeConfiguration : IEntityTypeConfiguration<InterestType>
    {
        public void Configure(EntityTypeBuilder<InterestType> builder)
        {
            //var data = new SeedData();
            //builder.HasData(data.interestTypeArr);
        }
    }
}
