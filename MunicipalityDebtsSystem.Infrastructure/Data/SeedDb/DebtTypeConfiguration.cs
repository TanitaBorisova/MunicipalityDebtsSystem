﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class DebtTypeConfiguration : IEntityTypeConfiguration<DebtType>
    {
        public void Configure(EntityTypeBuilder<DebtType> builder)
        {
            var data = new SeedData();
            var arr = data.debtTypeArr;
            builder.HasData(arr);
           
        }
    }
}
