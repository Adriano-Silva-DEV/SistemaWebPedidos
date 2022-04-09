using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaWebPedidos.Infrastructure.Persistence;

namespace SistemaWebPedidos.Api.Configurations
{
    public static class IdentityConfiguration
    {
   public static IServiceCollection AddIdentityConfiguration (this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>  
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")) );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
