using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Presentation.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StructuralMetadataDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("StructuralMetadataDatabase")));

            services.AddScoped<IStructuralMetadataDbContext>(provider => provider.GetService<StructuralMetadataDbContext>());

            return services;
        }
    }
}