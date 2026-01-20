using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Customers.Querries.GetById;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class GetByIdCustomerQuerryHandler : CommandHandlerBase, IRequestHandler<GetByIdCustomerQuery, CustomerDto>
    {
        public GetByIdCustomerQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
