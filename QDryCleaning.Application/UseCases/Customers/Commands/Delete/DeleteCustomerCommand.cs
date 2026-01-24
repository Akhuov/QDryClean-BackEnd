using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
