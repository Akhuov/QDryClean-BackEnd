using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Orders.Queries.GetById;

namespace QDryClean.Application.UseCases.Orders.Handlers
{
    public class GetByIdOrderCommandHandler : CommandHandlerBase, IRequestHandler<GetByIdOrderQuery, ApiResponse<OrderDto>>
    {
        public GetByIdOrderCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ApiResponse<OrderDto>> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            return ApiResponseFactory.Ok(_mapper.Map<OrderDto>(order));
        }
    }
}
