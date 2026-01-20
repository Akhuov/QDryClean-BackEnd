using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries.GetById
{
    public class GetByIdCustomerQuery: IRequest<CustomerDto> 
    {
        public int Id { get; set; }
    }
}
