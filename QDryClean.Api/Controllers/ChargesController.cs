using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Charges.Commands;
using QDryClean.Application.UseCases.Charges.Quarries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/v1/charges")]
    [ApiController]
    public class ChargesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChargesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateChargeAsync(CreateChargeCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Charge created successfully.", result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteChargeAsync(SoftDeleteChargeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateChargeAsync(UpdateChargeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChargesAsync()
        {
            var command = new GetAllChargesCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{chargeId:int}")]
        public async Task<IActionResult> GetByIdChargeAsync(int chargeId)
        {
            var command = new GetByIdChargeCommand() { Id = chargeId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
