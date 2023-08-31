using AutoMapper;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using IncomeTaxCalculator.Domain.Repositories;
using MediatR;

namespace IncomeTaxCalculator.Application.Queries
{
    public record GetAllTaxSystemsQuery() : IRequest<IEnumerable<TaxSystemViewModel>>
    {
        public class GetAllTaxSystemsQueryHandler : IRequestHandler<GetAllTaxSystemsQuery, IEnumerable<TaxSystemViewModel>>
        {
            private readonly IReadRepository<TaxSystem> _taxSystemReadRepository;
            private readonly IMapper _mapper;

            public GetAllTaxSystemsQueryHandler(
                IReadRepository<TaxSystem> taxSystemReadRepository,
                IMapper mapper)
            {
                _taxSystemReadRepository = taxSystemReadRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TaxSystemViewModel>> Handle(GetAllTaxSystemsQuery request, CancellationToken cancellationToken)
            {
                var taxSystems = await _taxSystemReadRepository.FindAllAsync(cancellationToken);

                return _mapper.Map<IEnumerable<TaxSystemViewModel>>(taxSystems);
            }
        }
    }
}
