using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORMAdapter.Contexts;

namespace ORMAdapter.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBService(this  IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
