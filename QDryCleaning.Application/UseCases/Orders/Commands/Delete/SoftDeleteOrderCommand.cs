using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.Orders.Commands.Delete
{
    public class SoftDeleteOrderCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
