using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Orders.Commands;

namespace QDryClean.Application.UseCases.Orders.Validators
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
                }).WithMessage("Customer with this Id does not exist");
        }
    }
}
