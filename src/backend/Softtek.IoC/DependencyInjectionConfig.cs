using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softtek.Data.Context;

namespace Softtek.IoC
{
    namespace Softtek.IoC.DependencyInjection
    {
        public static class DependencyInjectionConfig
        {
            public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
            {
                // DbContext
                services.AddDbContext<SofttekDbContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("SofttekDb")));

                return services;
            }
        }
    }
}
