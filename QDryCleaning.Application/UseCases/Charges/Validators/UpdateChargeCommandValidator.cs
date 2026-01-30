using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Charges.Commands;

namespace QDryClean.Application.UseCases.Charges.Validators
{
    public class UpdateChargeCommandValidator
        : AbstractValidator<UpdateChargeCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateChargeCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Charge ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.Charges
                        .AnyAsync(o => o.Id == id && o.DeletedAt == null && o.DeletedBy == null, cancellationToken);
                });

            RuleFor(x => x)
                .Must(x => !string.IsNullOrWhiteSpace(x.Name) || x.Cost > 0)
                .WithMessage("Either Name or Cost must be provided.");
        }
    }
}