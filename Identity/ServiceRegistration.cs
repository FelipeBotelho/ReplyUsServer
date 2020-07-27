using Application.Interfaces;
using Identity.Contexts;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("IdentityConnection"),
                        b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
        }
    }
}
