using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries.GetAll
{
    public class GetAllCustomersQuery : IRequest<ApiResponse<List<CustomerDto>>> { }
}
