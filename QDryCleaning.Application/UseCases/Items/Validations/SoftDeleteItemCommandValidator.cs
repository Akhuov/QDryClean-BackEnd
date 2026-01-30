using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Items.Commands;

namespace QDryClean.Application.UseCases.Items.Validations
{
    public class SoftDeleteItemCommandValidator
        : AbstractValidator<SoftDeleteItemCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public SoftDeleteItemCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Item ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.Items
                        .AnyAsync(i => i.Id == id && i.DeletedAt == null && i.DeletedBy == null, cancellationToken);
                })
                .WithMessage("Item with this ID does not exist");
        }
    }
}
