using AutoMapper;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using IncomeTaxCalculator.Domain.Repositories;
using MediatR;

namespace IncomeTaxCalculator.Application.Commands
{
    public record CreateTaxSystemCommand(
        string Name,
        IEnumerable<CreateTaxBandCommand> Bands) : IRequest<TaxSystemWithBandsViewModel>
    {
        public class CreateTaxSystemCommandHandler : IRequestHandler<CreateTaxSystemCommand, TaxSystemWithBandsViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IWriteRepository<TaxSystem> _taxSystemWriteRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CreateTaxSystemCommandHandler(
                IMapper mapper,
                IWriteRepository<TaxSystem> taxSystemWriteRepository,
                IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _taxSystemWriteRepository = taxSystemWriteRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<TaxSystemWithBandsViewModel> Handle(CreateTaxSystemCommand request, CancellationToken cancellationToken)
            {
                var taxSystemCreateData = _mapper.Map<TaxSystemCreateData>(request);

                var taxSystem = TaxSystem.CreateTaxSystem(taxSystemCreateData);

                await _taxSystemWriteRepository.AddAsync(taxSystem, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return _mapper.Map<TaxSystemWithBandsViewModel>(taxSystem);
            }
        }
    }

    public record CreateTaxBandCommand(
        long LowerLimit,
        long? UpperLimit,
        double Rate);
}
