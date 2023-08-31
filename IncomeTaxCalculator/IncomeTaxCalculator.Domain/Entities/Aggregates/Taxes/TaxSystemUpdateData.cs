namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public record TaxSystemUpdateData(
        string Name,
        IEnumerable<TaxBandUpdateData> Bands);

    public record TaxBandUpdateData(
        long LowerLimit,
        long? UpperLimit,
        double Rate) : ITaxBandData;
}
