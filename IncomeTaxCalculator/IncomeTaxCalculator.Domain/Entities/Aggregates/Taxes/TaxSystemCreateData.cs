namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public record TaxSystemCreateData(
        string Name,
        IEnumerable<TaxBandCreateData> Bands);

    public record TaxBandCreateData(
        long LowerLimit,
        long? UpperLimit,
        double Rate) : ITaxBandData;
}
