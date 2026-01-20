using MediatR;

namespace QDryClean.Application.UseCases.Customers.Commands.Delete
{
    public class SoftDeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
