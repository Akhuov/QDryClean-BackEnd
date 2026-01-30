using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.ItemCategories.Commands;

namespace QDryClean.Application.UseCases.ItemCategories.Validators
{
    public class UpdateItemCategoryCommandValidator
        : AbstractValidator<UpdateItemCategoryCommand>
    {

        private readonly IApplicationDbContext _dbContext;
        public UpdateItemCategoryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Item Category ID is required.")
                .GreaterThan(0)
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.ItemCategories
                        .AnyAsync(ic => ic.Id == id && ic.DeletedAt == null && ic.DeletedBy == null, cancellationToken);
                }).WithMessage("Item Category with this ID does not exist");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Item Category Name is required.")
                .MaximumLength(100).WithMessage("Item Category Name must not exceed 100 characters.");
        }
    }
}
