namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class NegativeTaxRateProvidedDomainException : DomainException
    {
        private const string ErrorMessage = "Negative tax rate provided";

        public NegativeTaxRateProvidedDomainException() : this(ErrorMessage)
        {
        }

        public NegativeTaxRateProvidedDomainException(string message)
            : base(message)
        {
        }

        public NegativeTaxRateProvidedDomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
