using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<ApiResponse<OrderDto>>
    {
        public int? DaysToCompletion { get; set; } = null;
        public int CustomerId { get; set; }
        //public ICollection<Item> Items { get; set; } = new List<Item>();
        public string? Note { get; set; }
    }
}
