using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.UseCases.Customers.Commands.Delete;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class SoftDeleteCustomerCommandHandler : CommandHandlerBase, IRequestHandler<SoftDeleteCustomerCommand, string>
    {

        public SoftDeleteCustomerCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<string> Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            customer.DeletedAt = DateTime.Now;
            customer.DeletedBy = _currentUserService.UserId;

            _applicationDbContext.Customers.Update(customer);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return $"Customer {customer.FirstName} Deleted Succesfully!";

        }
    }
}
