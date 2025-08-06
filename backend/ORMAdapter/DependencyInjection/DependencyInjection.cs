using Application.Interfaces.Db;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORMAdapter.Contexts;
using ORMAdapter.Repositories;
using ORMAdapter.Services;

namespace ORMAdapter.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBService(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIncomingDocumentRepository, IncomingDocumentRepository>();
            services.AddScoped<IIncomingResourceRepository, IncomingResourceRepository>();
            services.AddScoped<IOutgoingDocumentRepository, OutgoingDocumentRepository>();
            services.AddScoped<IOutgoingResourceRepository, OutgoingResourceRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IUnitOfMeasurementRepository, UnitOfMeasurementRepository>();

            return services;
        }
        public static IServiceCollection RegisterDbServices(this IServiceCollection services)
        {
            services.AddScoped<IDbTransactionService, TransactionService>();

            return services;
        }
    }
}
