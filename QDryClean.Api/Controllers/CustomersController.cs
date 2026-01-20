using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Customers.Commands.Create;
using QDryClean.Application.UseCases.Customers.Commands.Delete;
using QDryClean.Application.UseCases.Customers.Commands.Update;
using QDryClean.Application.UseCases.Customers.Querries.GetAll;
using QDryClean.Application.UseCases.Customers.Querries.GetById;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command); 
            return Created("User created successfully.", result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete("{customerId:int}")]
        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            var result = await _mediator.Send(new SoftDeleteCustomerCommand() { Id = customerId });
            return Ok(result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(UpdateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var command = new GetAllCustomersQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> GetByIdCustomerAsync(int customerId)
        {
            var result = await _mediator.Send(new GetByIdCustomerQuery() { Id = customerId });
            return Ok(result);
        }
    }
}
