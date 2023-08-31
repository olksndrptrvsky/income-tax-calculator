namespace IncomeTaxCalculator.Application.Models
{
    public record TaxesViewModel(
        double GrossAnnualSalary,
        double GrossMonthlySalary,
        double NetAnnualSalary,
        double NetMonthlySalary,
        double AnnualTaxPaid,
        double MonthlyTaxPaid);

}
