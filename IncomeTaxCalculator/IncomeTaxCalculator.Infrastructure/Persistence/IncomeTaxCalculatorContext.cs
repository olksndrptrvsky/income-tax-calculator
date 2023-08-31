using Microsoft.EntityFrameworkCore;

namespace IncomeTaxCalculator.Infrastructure.Persistence
{
    public class IncomeTaxCalculatorContext : DbContext
    {

        public IncomeTaxCalculatorContext() : base()
        {
        }

        public IncomeTaxCalculatorContext(DbContextOptions<IncomeTaxCalculatorContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IncomeTaxCalculatorContext).Assembly);
        }
    }
}
