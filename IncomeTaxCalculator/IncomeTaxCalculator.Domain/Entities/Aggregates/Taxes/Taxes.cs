namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public record Taxes(
        double GrossAnnualSalary,
        double GrossMonthlySalary,
        double NetAnnualSalary,
        double NetMonthlySalary,
        double AnnualTaxPaid,
        double MonthlyTaxPaid);
}
