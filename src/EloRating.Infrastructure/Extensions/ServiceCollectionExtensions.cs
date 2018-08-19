using EloRating.Core.Interfaces;
using EloRating.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EloRating.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {                
        public static IServiceCollection AddDataStore(this IServiceCollection services,
                                               string connectionString, bool useInMemoryDatabase = false)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            return services.AddDbContext<AppDbContext>(options =>
            {
                _ = useInMemoryDatabase 
                ? options.UseInMemoryDatabase(databaseName: "EloRating")
                : options.UseSqlServer(connectionString, b => b.MigrationsAssembly("EloRating.Infrastructure"));
            });          
        }
    }
}
