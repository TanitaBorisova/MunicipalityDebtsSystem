using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class DebtPurposeTypeConfiguration : IEntityTypeConfiguration<DebtPurposeType>
    {
        public void Configure(EntityTypeBuilder<DebtPurposeType> builder)
        {
            //var data = new SeedData();
            //builder.HasData(data.debtPurposeTypeArr);
        }
    }
}
