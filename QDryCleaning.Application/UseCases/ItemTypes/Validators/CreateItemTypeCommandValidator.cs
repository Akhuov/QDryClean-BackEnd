using FluentValidation;
using QDryClean.Application.UseCases.ItemTypes.Commands;

namespace QDryClean.Application.UseCases.ItemTypes.Validators
{
    public class CreateItemTypeCommandValidator
        : AbstractValidator<CreateItemTypeCommand>
    {
        public CreateItemTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Item Type Name is required.")
                .MaximumLength(100).WithMessage("Item Type Name must not exceed 100 characters.");

            RuleFor(x => x.ItemCategoryId)
                .NotEmpty().WithMessage("Item Category ID is required.")
                .NotNull().WithMessage("Item Category ID is required.")
                .GreaterThan(0).WithMessage("Item Category ID must be greater than zero.");

            RuleFor(x => x.ChargeId)
                .NotNull().WithMessage("Charge ID is required.")
                .NotEmpty().WithMessage("Charge ID is required.")
                .GreaterThan(0).WithMessage("Charge ID must be greater than zero.");
        }
    }
}
