using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries.GetAll
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>> { }
}
