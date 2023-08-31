using AutoMapper;
using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using IncomeTaxCalculator.Domain.Repositories;
using MediatR;

namespace IncomeTaxCalculator.Application.Commands
{
    public record UpdateTaxSystemCommand(
        int Id,
        string Name,
        IEnumerable<UpdateTaxBandCommand> Bands) : IRequest
    {
        public class UpdateTaxSystemCommandHandler : IRequestHandler<UpdateTaxSystemCommand>
        {
            private readonly IMapper _mapper;
            private readonly ITaxSystemWriteRepository _taxSystemWriteRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateTaxSystemCommandHandler(
                IMapper mapper,
                ITaxSystemWriteRepository taxSystemWriteRepository,
                IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _taxSystemWriteRepository = taxSystemWriteRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task Handle(UpdateTaxSystemCommand request, CancellationToken cancellationToken)
            {
                var taxSystemUpdateData = _mapper.Map<TaxSystemUpdateData>(request);

                var taxSystem = await _taxSystemWriteRepository.GetTaxSystemWithBandsAsync(request.Id, cancellationToken);

                if (taxSystem is null)
                {
                    throw new ArgumentException($"There is no tax system with Id = {request.Id}");
                }

                taxSystem.Update(taxSystemUpdateData);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }

    public record UpdateTaxBandCommand(
        long LowerLimit,
        long? UpperLimit,
        double Rate);
}
