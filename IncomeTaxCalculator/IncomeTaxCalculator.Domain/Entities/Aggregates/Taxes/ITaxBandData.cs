namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public interface ITaxBandData
    {
        long LowerLimit { get; }
        long? UpperLimit { get; }
        double Rate { get; }
    }
}
