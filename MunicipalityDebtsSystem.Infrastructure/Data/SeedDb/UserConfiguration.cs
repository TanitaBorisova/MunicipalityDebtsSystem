using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
            
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            var data = new SeedUsers();
           

           // builder.HasData(new IdentityRole[] { data., data.burgasMunicipalityUser});

            builder.HasData(new ApplicationUser[] { data.adminUser, data.burgasMunicipalityUser, data.varnaMunicipalityUser });
            
            
        }
    }
}
