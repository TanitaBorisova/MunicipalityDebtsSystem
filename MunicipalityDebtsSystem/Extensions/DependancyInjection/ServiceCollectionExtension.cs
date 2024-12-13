using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Services;
using MunicipalityDebtsSystem.Infrastructure.Data;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;

namespace MunicipalityDebtsSystem.Extensions.DependancyInjection
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IDrawService, DrawService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMunicipalityService, MunicipalityService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<ICoverService, CoverService>();

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

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

           // .AddDefaultTokenProviders();

            return services;
        }

        //public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        //{
        //    services
        //        .AddDefaultIdentity<ApplicationUser>(options =>
        //        {
        //            options.User.RequireUniqueEmail = true;
        //            options.SignIn.RequireConfirmedAccount = false;
        //            options.Password.RequireNonAlphanumeric = false;
        //            options.Password.RequireDigit = true;
        //            options.Password.RequireLowercase = true;
        //            options.Password.RequireUppercase = true;
        //        })
        //        //.AddRoles<IdentityRole>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>();

        //    return services;
        //}

    }
}
