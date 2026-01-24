using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Orders.Queries.GetAll
{
    public class GetAllOrdersQuery : IRequest<ApiResponse<List<OrderDto>>> { }
}
