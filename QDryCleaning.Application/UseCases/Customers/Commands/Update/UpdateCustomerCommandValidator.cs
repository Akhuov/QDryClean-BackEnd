using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;

namespace QDryClean.Application.UseCases.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateCustomerCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Customer ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.Customers.AnyAsync(c => c.Id == id, cancellationToken);
                })
                .WithMessage("Customer with this Id does not exist");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number is required")
                .Matches(@"^(?:\+998|998)?\s?\d{2}\s?\d{3}\s?\d{2}\s?\d{2}$")
                .WithMessage("Invalid phone number format")
                .MustAsync(async (command, phone, cancellationToken) =>
                {
                    return !await _dbContext.Customers
                        .AnyAsync(c => c.PhoneNumber == phone && c.Id != command.Id && c.DeletedAt == null && c.DeletedBy == null, cancellationToken);
                })
                .WithMessage("Customer with this phone number already exists");
        }
    }
}
