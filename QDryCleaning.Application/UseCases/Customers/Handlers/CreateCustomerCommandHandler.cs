using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Exceptions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Customers.Commands.Create;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class CreateCustomerCommandHandler : CommandHandlerBase, IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        public CreateCustomerCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _applicationDbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);

            customer = _mapper.Map<Customer>(request);
            customer.CreatedBy = _currentUserService.UserId;
            customer.CreatedAt = DateTime.Now;

            await _applicationDbContext.Customers.AddAsync(customer, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
