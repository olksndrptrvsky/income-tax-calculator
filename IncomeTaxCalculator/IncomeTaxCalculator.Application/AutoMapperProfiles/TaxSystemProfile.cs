using AutoMapper;
using IncomeTaxCalculator.Application.Commands;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Application.Queries;
using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;

namespace IncomeTaxCalculator.Application.AutoMapperProfiles
{
    public class TaxSystemProfile : Profile
    {
        public TaxSystemProfile()
        {
            CreateMap<CreateTaxSystemCommand, TaxSystemCreateData>();
            CreateMap<CreateTaxBandCommand, TaxBandCreateData>();

            CreateMap<UpdateTaxSystemCommand, TaxSystemUpdateData>();
            CreateMap<UpdateTaxBandCommand, TaxBandUpdateData>();

            CreateMap<TaxSystem, TaxSystemWithBandsViewModel>();
            CreateMap<TaxSystem, TaxSystemViewModel>();
            CreateMap<TaxBand, TaxBandViewModel>();

            CreateMap<Taxes,  TaxesViewModel>();
        }
    }
}
