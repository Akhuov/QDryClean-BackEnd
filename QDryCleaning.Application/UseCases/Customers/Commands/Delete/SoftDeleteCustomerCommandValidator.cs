using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;

namespace QDryClean.Application.UseCases.Customers.Commands.Delete
{
    public class SoftDeleteCustomerCommandValidator : AbstractValidator<SoftDeleteCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public SoftDeleteCustomerCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Customer ID is required.")
                .GreaterThan(0).WithMessage("Customer ID must be greater than 0.")
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.Customers.AnyAsync(c => c.Id == id && c.DeletedAt == null && c.DeletedBy == null, cancellationToken);
                })
                .WithMessage("Customer with this ID does not exist");
        }
    }
}