using IncomeTaxCalculator.Domain.Entities.Common;

namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public class TaxBand : Entity
    {
        public long LowerLimit { get; private set; }

        public long? UpperLimit { get; private set; }

        public double Rate { get; private set; }

        public TaxSystem TaxSystem { get; private set; } = new();

        public static TaxBand CreateTaxBand(ITaxBandData data, TaxSystem taxSystem)
        {
            return new TaxBand()
            {
                LowerLimit = data.LowerLimit,
                UpperLimit = data.UpperLimit,
                Rate = data.Rate,
                TaxSystem = taxSystem,
            };
        }

        public void Update(TaxBandUpdateData data)
        {
            LowerLimit = data.LowerLimit;
            UpperLimit = data.UpperLimit;
            Rate = data.Rate;
        }

        public double CalculateTax(double annualIncome)
        {
            return (annualIncome <= LowerLimit, UpperLimit is null, annualIncome <= UpperLimit) switch
            {
                (true, _, _) => 0,
                (false, true, _) => (annualIncome - LowerLimit) * Rate,
                (false, false, true) => (annualIncome - LowerLimit) * Rate,
                (false, false, false) => (UpperLimit!.Value -  LowerLimit) * Rate
            };
        }
    }
}
