using IncomeTaxCalculator.Application.Commands;
using IncomeTaxCalculator.Application.Models;
using IncomeTaxCalculator.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeTaxCalculator.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxSystemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private const string GetTaxSystemActionName = "GetTaxSystem";

        public TaxSystemsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}"), ActionName(GetTaxSystemActionName)]
        public async Task<TaxSystemWithBandsViewModel> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTaxSystemQuery(id), cancellationToken);
        }

        [HttpGet]
        public async Task<IEnumerable<TaxSystemViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllTaxSystemsQuery(), cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<TaxSystemWithBandsViewModel>> CreateAsync(CreateTaxSystemCommand command, CancellationToken cancellationToken)
        {
            var taxSystem = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(GetTaxSystemActionName, new { taxSystem.Id }, taxSystem);
        }

        [HttpGet("{id}/taxes")]
        public async Task<TaxesViewModel> GetTaxesAsync(int id, double annualSalary, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTaxesQuery(id, annualSalary), cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(int id, UpdateTaxSystemCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command with { Id = id }, cancellationToken);
        }
    }
}