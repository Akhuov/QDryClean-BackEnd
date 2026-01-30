using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.ItemCategories.Querries;

namespace QDryClean.Application.UseCases.ItemCategories.Validators
{
    public class GetByIdItemCategoryQuerryValidator
        : AbstractValidator<GetByIdItemCategoryQuerry>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetByIdItemCategoryQuerryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Item Category ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.ItemCategories
                        .AnyAsync(ic => ic.Id == id && ic.DeletedAt == null && ic.DeletedBy == null, cancellationToken);
                })
                .WithMessage("Item Category with this ID does not exist");
        }
    }
}