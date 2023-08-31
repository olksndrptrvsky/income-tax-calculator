namespace IncomeTaxCalculator.Application.Models
{
    public record TaxSystemWithBandsViewModel(
        int Id,
        string Name,
        IEnumerable<TaxBandViewModel> Bands);

    public record TaxBandViewModel(
        long LowerLimit,
        long? UpperLimit,
        double Rate);
}
