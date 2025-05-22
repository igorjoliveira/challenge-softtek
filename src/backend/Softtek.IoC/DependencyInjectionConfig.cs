using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softtek.Application.Interfaces.Services;
using Softtek.Application.MappingProfiles;
using Softtek.Application.Services;
using Softtek.Data.Context;
using Softtek.Data.Repositories;
using Softtek.Domain.Repositories;

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

                services.AddAutoMapper(typeof(AvaliacaoMappingProfile));

                services.AddScoped<IAvaliacaoService, AvaliacaoService>();
                services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
                services.AddScoped<IRegistroRepository, RegistroRepository>();


                return services;
            }
        }
    }
}
