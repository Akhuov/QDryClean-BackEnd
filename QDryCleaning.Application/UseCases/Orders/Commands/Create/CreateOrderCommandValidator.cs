using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;

namespace QDryClean.Application.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommandValidator
        : AbstractValidator<CreateOrderCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateOrderCommandValidator(IApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, customerId, CancellationToken) =>
                {
                    return await _dbContext.Customers.AnyAsync(c => c.Id == customerId && c.DeletedAt == null && c.DeletedBy == null, CancellationToken);
                });
        }
    }
}
