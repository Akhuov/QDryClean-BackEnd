using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Customers.Queries.GetAll;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class GetAllCustomersQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllCustomersQuery, ApiResponse<List<CustomerDto>>>
    {
        public GetAllCustomersQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ApiResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {

            var customers = await _applicationDbContext.Customers.Where(x => x.DeletedAt == null && x.DeletedBy == null).ToListAsync();

            var list_of_customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                list_of_customerDtos.Add(_mapper.Map<CustomerDto>(customer));
            }

            return ApiResponseFactory.Ok(list_of_customerDtos);
        }
    }
}
