using Microsoft.AspNetCore.Identity;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class SeedUsers
    {
        //public UserManager<ApplicationUser> userManager;
        //public RoleManager<IdentityRole> roleManager;

        public ApplicationUser adminUser { get; set; }
        public IdentityUserClaim<string> AdminUserClaim { get; set; }
        public IdentityUserClaim<string> AdminMunicipalityIdClaim { get; set; }
        public IdentityUserClaim<string> AdminMunicipalityNameClaim { get; set; }
        public IdentityUserClaim<string> AdminMunicipalityCodeClaim { get; set; }
        public ApplicationUser burgasMunicipalityUser { get; set; }
        public IdentityUserClaim<string> BurgasMunicipalityIdClaim { get; set; }
        public IdentityUserClaim<string> BurgasMunicipalityNameClaim { get; set; }
        public IdentityUserClaim<string> BurgasMunicipalityCodeClaim { get; set; }
        public IdentityUserClaim<string> BurgasUserClaim { get; set; }
        public ApplicationUser varnaMunicipalityUser { get; set; }
        public IdentityUserClaim<string> VarnaUserClaim { get; set; }
        public IdentityUserClaim<string> VarnaMunicipalityIdClaim { get; set; }
        public IdentityUserClaim<string> VarnaMunicipalityNameClaim { get; set; }
        public IdentityUserClaim<string> VarnaMunicipalityCodeClaim { get; set; }

        public SeedUsers()
        {
                      
            SeedSomeUsers();
        }

        
        public void SeedSomeUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            adminUser = new ApplicationUser()
            {
                Id = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                UserName = "adminDebt@mail.bg",
                NormalizedUserName = "ADMINDEBT@MAIL.COM",
                Email = "adminDebt@mail.bg",
                NormalizedEmail = "ADMINDEBT@MAIL.COM",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 3,
                LockoutEnabled = false,
                FirstName = "Иван",
                LastName = "Петров",
                MunicipalityId = null
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 20,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Иван Петров",
                UserId = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3"
            };
            AdminMunicipalityIdClaim = new IdentityUserClaim<string>()
            {
                Id = 21,
                ClaimType = UserMunicipalityIdClaim,
                ClaimValue = "",
                UserId = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3"
            };
            AdminMunicipalityNameClaim = new IdentityUserClaim<string>()
            {
                Id = 22,
                ClaimType = UserMunicipalityNameClaim,
                ClaimValue = "",
                UserId = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3"
            };
            AdminMunicipalityCodeClaim = new IdentityUserClaim<string>()
            {
                Id = 23,
                ClaimType = UserMunicipalityCodeClaim,
                ClaimValue = "",
                UserId = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3"
            };

            adminUser.PasswordHash =
                 hasher.HashPassword(adminUser, "DebtAdmin123");

            burgasMunicipalityUser = new ApplicationUser()
            {
                Id = "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                UserName = "burgas_municipal@mail.bg",
                NormalizedUserName = "BURGAS_MUNICIPAL@MAIL.BG",  //BURGAS_MUNICIPAL@MAIL.BG
                Email = "burgas_municipal@mail.bg",
                NormalizedEmail = "BURGAS_MUNICIPAL@MAIL.BG",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 3,
                LockoutEnabled = false,
                FirstName = "Стоян",
                LastName = "Георгиев",
                MunicipalityId = 16
            };

            BurgasUserClaim = new IdentityUserClaim<string>()
            {
                Id = 24,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Стоян Георгиев",
                UserId = "22ad10a0-2f69-4735-bd2c-9e944cd80baf"
            };
            BurgasMunicipalityIdClaim = new IdentityUserClaim<string>()
            {
                Id = 25,
                ClaimType = UserMunicipalityIdClaim,
                ClaimValue = "16",
                UserId = "22ad10a0-2f69-4735-bd2c-9e944cd80baf"
            };
            BurgasMunicipalityNameClaim = new IdentityUserClaim<string>()
            {
                Id = 26,
                ClaimType = UserMunicipalityNameClaim,
                ClaimValue = "Бургас",
                UserId = "22ad10a0-2f69-4735-bd2c-9e944cd80baf"
            };
            BurgasMunicipalityCodeClaim = new IdentityUserClaim<string>()
            {
                Id = 27,
                ClaimType = UserMunicipalityCodeClaim,
                ClaimValue = "5202",
                UserId = "22ad10a0-2f69-4735-bd2c-9e944cd80baf"
            };

            burgasMunicipalityUser.PasswordHash =
            hasher.HashPassword(burgasMunicipalityUser, "BurgasMun123");

            varnaMunicipalityUser = new ApplicationUser()
            {
                 Id = "faf648ad-8f38-459d-909f-256f9a167a44",
                UserName = "VarnaMun@mail.com",
                NormalizedUserName = "VARNAMUN@MAIL.COM",
                Email = "VarnaMun@mail.com",
                NormalizedEmail = "VARNAMUN@MAIL.COM",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 3,
                LockoutEnabled = false,
                FirstName = "Георги",
                LastName = "Василев",
                MunicipalityId = 32
            };

            VarnaUserClaim = new IdentityUserClaim<string>()
            {
                Id = 28,
                ClaimType = UserFullNameClaim,
                UserId = "faf648ad-8f38-459d-909f-256f9a167a44",
                ClaimValue = "Георги Василев"
            };

            VarnaMunicipalityIdClaim = new IdentityUserClaim<string>()
            {
                Id = 29,
                ClaimType = UserMunicipalityIdClaim,
                UserId = "faf648ad-8f38-459d-909f-256f9a167a44",
                ClaimValue = "32"
            };
            VarnaMunicipalityNameClaim = new IdentityUserClaim<string>()
            {
                Id = 30,
                ClaimType = UserMunicipalityNameClaim,
                UserId = "faf648ad-8f38-459d-909f-256f9a167a44",
                ClaimValue = "Варна"
            };
            VarnaMunicipalityCodeClaim = new IdentityUserClaim<string>()
            {
                Id = 31,
                ClaimType = UserMunicipalityCodeClaim,
                UserId = "faf648ad-8f38-459d-909f-256f9a167a44",
                ClaimValue = "5305"
            };

            varnaMunicipalityUser.PasswordHash =
            hasher.HashPassword(varnaMunicipalityUser, "VarnaMun123");
        }

        //public async Task SeedRolesToUsers()
        //{
        //    var admin = await userManager.FindByEmailAsync("adminDebt@mail.bg");

        //    if (admin != null)
        //    {
        //        await userManager.AddToRoleAsync(admin, "Administrator");
        //    }

        //    var burgasUser = await userManager.FindByEmailAsync("burgas_municipal@mail.bg");
        //    if (burgasUser != null)
        //    {
        //        await userManager.AddToRoleAsync(burgasUser, "UserMun");
        //    }

        //    var varnaUser = await userManager.FindByEmailAsync("VarnaMun@mail.com");
        //    if (varnaUser != null)
        //    {
        //        await userManager.AddToRoleAsync(varnaUser, "UserMun");
        //    }
        //}

    }
}
