using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Commands.Update
{
    public class UpdateCustomerCommand: CustomerDto, IRequest<ApiResponse<CustomerDto>>{ }
}
