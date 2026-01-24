using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries.GetById
{
    public class GetByIdCustomerQuery: IRequest<ApiResponse<CustomerDto>>
    {
        public int Id { get; set; }
    }
}
