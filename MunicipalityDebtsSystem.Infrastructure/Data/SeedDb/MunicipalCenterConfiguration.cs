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
    public class MunicipalCenterConfiguration : IEntityTypeConfiguration<MunicipalCenter>
    {
        public void Configure(EntityTypeBuilder<MunicipalCenter> builder)
        {
            var data = new SeedData();
            var arr = data.municipalCenterArr;
            builder.HasData(arr);
        }
    }
}
