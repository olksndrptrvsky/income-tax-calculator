namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class WrongTaxCoverageDomainException : DomainException
    {
        private const string ErrorMessageTemplate = "There is a gap in tax coverage on [{0}; {1}]";

        public long? StartOfGap { get; init; }

        public long? EndOfGap{ get; init; }


        public WrongTaxCoverageDomainException(long? startOfGap, long? endOfGap)
            : this(string.Format(ErrorMessageTemplate, startOfGap, endOfGap))
        {
            StartOfGap = startOfGap;
            EndOfGap = endOfGap;
        }

        public WrongTaxCoverageDomainException(string message)
            : base(message)
        {
        }

        public WrongTaxCoverageDomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
