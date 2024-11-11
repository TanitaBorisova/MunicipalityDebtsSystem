using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;

namespace MunicipalityDebtsSystem.Extensions.DependancyInjection
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<ApplicationDbContext>();


            //AddIdentity iska i user i role
            //Trqbva li da scaffold-na?

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    //.AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
                   
                    //.AddDefaultTokenProviders();

            return services;
        }



    }
}
