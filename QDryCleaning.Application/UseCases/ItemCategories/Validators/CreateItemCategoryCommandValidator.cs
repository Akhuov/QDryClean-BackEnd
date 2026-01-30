using FluentValidation;
using QDryClean.Application.UseCases.ItemCategories.Commands;

namespace QDryClean.Application.UseCases.ItemCategories.Validators
{
    public class CreateItemCategoryCommandValidator
        : AbstractValidator<CreateItemCategoryCommand>
    {
        public CreateItemCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Item Category Name is required.")
                .MaximumLength(100).WithMessage("Item Category Name must not exceed 100 characters.");
        }
    }
}