using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new SeedUsers();

            builder.HasData(new IdentityUserClaim<string>[] { data.AdminUserClaim, data.AdminMunicipalityIdClaim, data.AdminMunicipalityNameClaim, data.AdminMunicipalityCodeClaim, data.BurgasUserClaim, data.BurgasMunicipalityIdClaim, data.BurgasMunicipalityNameClaim, data.BurgasMunicipalityCodeClaim,data.VarnaUserClaim, data.VarnaMunicipalityIdClaim, data.VarnaMunicipalityNameClaim, data.VarnaMunicipalityCodeClaim });
        }
    }
}
