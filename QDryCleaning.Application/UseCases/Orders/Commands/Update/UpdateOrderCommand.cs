using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequest<ApiResponse<OrderDto>>
    {
        public int Id { get; set; } 
        public ProcessStatus ProcessStatus { get; set; }
        public string? Note { get; set; }
    }
}
