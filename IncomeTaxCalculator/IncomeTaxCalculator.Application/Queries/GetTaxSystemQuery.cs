using AutoMapper;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Domain.Repositories;
using MediatR;

namespace IncomeTaxCalculator.Application.Queries
{
    public record GetTaxSystemQuery(int Id) : IRequest<TaxSystemWithBandsViewModel>
    {
        public class GetTaxSystemQueryHandler : IRequestHandler<GetTaxSystemQuery, TaxSystemWithBandsViewModel>
        {
            private readonly ITaxSystemReadRepository _taxSystemReadRepository;
            private readonly IMapper _mapper;

            public GetTaxSystemQueryHandler(
                ITaxSystemReadRepository taxSystemReadRepository,
                IMapper mapper)
            {
                _taxSystemReadRepository = taxSystemReadRepository;
                _mapper = mapper;
            }

            public async Task<TaxSystemWithBandsViewModel> Handle(GetTaxSystemQuery request, CancellationToken cancellationToken)
            {
                var taxSystem = await _taxSystemReadRepository.GetTaxSystemWithBandsAsync(request.Id, cancellationToken);

                return _mapper.Map<TaxSystemWithBandsViewModel>(taxSystem);
            }
        }
    }
}
