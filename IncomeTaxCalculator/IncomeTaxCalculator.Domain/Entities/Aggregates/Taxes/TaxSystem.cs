using IncomeTaxCalculator.Domain.Entities.Common;
using IncomeTaxCalculator.Domain.Exceptions;

namespace IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes
{
    public class TaxSystem : Entity, IAggregateRoot
    {
        private readonly List<TaxBand> _bands = new();

        public IReadOnlyCollection<TaxBand> Bands => _bands.AsReadOnly();

        public string Name { get; private set; } = string.Empty;

        public static TaxSystem CreateTaxSystem(TaxSystemCreateData data)
        {
            CheckBands(data.Bands);
            var taskSystem = new TaxSystem() { Name = data.Name };
            taskSystem.UpdateBands(data.Bands);
            return taskSystem;
        }

        public void Update(TaxSystemUpdateData data)
        {
            CheckBands(data.Bands);
            Name = data.Name;
            UpdateBands(data.Bands);
        }

        public Taxes CalculateTaxes(double annualSalary)
        {
            var totalTaxesPaid = Bands.Sum(x => x.CalculateTax(annualSalary));

            return new Taxes(
                GrossAnnualSalary: annualSalary,
                GrossMonthlySalary: annualSalary / 12,
                NetAnnualSalary: annualSalary - totalTaxesPaid,
                NetMonthlySalary: (annualSalary - totalTaxesPaid) / 12,
                AnnualTaxPaid: totalTaxesPaid,
                MonthlyTaxPaid: totalTaxesPaid / 12);
        }

        private static void CheckBands(IEnumerable<ITaxBandData> taxBands)
        {
            if (taxBands?.Any() is not true)
            {
                throw new NoTaxBandsProvidedDomainException();
            }

            CheckBandsLimitsForIntersection(taxBands);

            CheckBandsLimitsForGaps(taxBands);
        }

        private static void CheckBandsLimitsForIntersection(IEnumerable<ITaxBandData> taxBands)
        {
            if (taxBands.Where(x => x.UpperLimit is null).Count() > 1)
            {
                throw new WrongTaxCoverageDomainException("Exactly one band with no upper limit should exist");
            }

            foreach (var band in taxBands.Where(x => x.UpperLimit is not null))
            {
                var intersectedBand = taxBands
                    .FirstOrDefault(x => x.LowerLimit < band.UpperLimit && band.UpperLimit < (x.UpperLimit ?? long.MaxValue));

                if (intersectedBand is not null)
                {
                    throw new TaxBandsLimitsIntersectedDomainException(intersectedBand.LowerLimit, band.UpperLimit);
                }
            }
        }

        private static void CheckBandsLimitsForGaps(IEnumerable<ITaxBandData> taxBands)
        {
            if (taxBands.Where(x => x.UpperLimit is null).Count() < 1)
            {
                throw new WrongTaxCoverageDomainException("Exactly one band with no upper limit should exist");
            }

            foreach (var band in taxBands.Where(x => x.UpperLimit is not null))
            {
                var gapExists = !taxBands.Any(x => band.UpperLimit == x.LowerLimit);

                if (gapExists)
                {
                    var nearestBandLimit = taxBands
                        .Select(x => x.LowerLimit)
                        .OrderBy(x => x)
                        .FirstOrDefault(x => x > band.UpperLimit);
                    throw new WrongTaxCoverageDomainException(band.UpperLimit, nearestBandLimit);
                }
            }
        }

        private void UpdateBands(IEnumerable<ITaxBandData> newTaxBands)
        {
            _bands.Clear();
            foreach (var band in newTaxBands)
            {
                _bands.Add(TaxBand.CreateTaxBand(band, this));
            }
        }
    }
}
