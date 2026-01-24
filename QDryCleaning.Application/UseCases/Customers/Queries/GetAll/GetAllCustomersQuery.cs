using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Queries.GetAll
{
    public class GetAllCustomersQuery : IRequest<ApiResponse<List<CustomerDto>>> { }
}
