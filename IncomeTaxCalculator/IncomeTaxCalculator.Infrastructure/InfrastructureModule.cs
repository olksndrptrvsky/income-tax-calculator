using IncomeTaxCalculator.Domain.Repositories;
using IncomeTaxCalculator.Infrastructure.Persistence;
using IncomeTaxCalculator.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculator.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IncomeTaxCalculatorContext>(options =>
            {
                options.UseInMemoryDatabase("IncomeTaxCalculator");
                // TODO: Update to real db
                //options.UseSqlite(connectionString));
            });

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped<ITaxSystemReadRepository, TaxSystemReadRepository>();
            services.AddScoped<ITaxSystemWriteRepository, TaxSystemWriteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
