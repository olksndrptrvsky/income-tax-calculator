namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class TaxBandsLimitsIntersectedDomainException : DomainException
    {
        private const string ErrorMessageTemplate = "Tax band limits intersected on [{0}; {1}]";

        public long? StartOfIntersection { get; init; }

        public long? EndOfIntersection { get; init; }


        public TaxBandsLimitsIntersectedDomainException(long? startOfIntersection, long? endOfIntersection)
            : this(string.Format(ErrorMessageTemplate, startOfIntersection, endOfIntersection))
        {
            StartOfIntersection = startOfIntersection;
            EndOfIntersection = endOfIntersection;
        }

        public TaxBandsLimitsIntersectedDomainException(string message)
            : base(message)
        {
        }

        public TaxBandsLimitsIntersectedDomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
