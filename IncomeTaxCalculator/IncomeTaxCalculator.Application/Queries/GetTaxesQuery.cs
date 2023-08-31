using AutoMapper;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Domain.Repositories;
using MediatR;

namespace IncomeTaxCalculator.Application.Queries
{
    public record GetTaxesQuery(int TaxSystemId, double AnnualSalary) : IRequest<TaxesViewModel>
    {
        public class GetTaxesQueryHandler : IRequestHandler<GetTaxesQuery, TaxesViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ITaxSystemReadRepository _taxSystemReadRepository;

            public GetTaxesQueryHandler(
                IMapper mapper,
                ITaxSystemReadRepository taxSystemReadRepository)
            {
                _mapper = mapper;
                _taxSystemReadRepository = taxSystemReadRepository;
            }

            public async Task<TaxesViewModel> Handle(GetTaxesQuery request, CancellationToken cancellationToken)
            {
                var taxSystem = await _taxSystemReadRepository.GetTaxSystemWithBandsAsync(request.TaxSystemId, cancellationToken);

                if (taxSystem is null)
                {
                    throw new ArgumentException($"There is no tax system with Id = {request.TaxSystemId}");
                }

                return _mapper.Map<TaxesViewModel>(taxSystem.CalculateTaxes(request.AnnualSalary));
            }
        }
    }
}
