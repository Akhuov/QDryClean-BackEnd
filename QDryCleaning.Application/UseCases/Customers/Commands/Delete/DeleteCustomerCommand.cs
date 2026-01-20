using MediatR;

namespace QDryClean.Application.UseCases.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
