namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class NoTaxBandsProvidedDomainException : DomainException
    {
        private const string ErrorMessage = "No Tax Bands have been provided";

        public NoTaxBandsProvidedDomainException() : this(ErrorMessage)
        {
        }

        public NoTaxBandsProvidedDomainException(string message)
            : base(message)
        {
        }

        public NoTaxBandsProvidedDomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
