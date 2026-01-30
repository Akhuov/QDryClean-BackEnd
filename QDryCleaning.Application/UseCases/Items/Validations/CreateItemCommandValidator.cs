using FluentValidation;
using QDryClean.Application.UseCases.Items.Commands;

namespace QDryClean.Application.UseCases.Items.Validations
{
    public class CreateItemCommandValidator
        : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {

            RuleFor(x => x.ItemTypeId)
                .NotEmpty().WithMessage("Item type ID is required.")
                .GreaterThan(0).WithMessage("Item category ID must be greater than zero.");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Order ID must be greater than zero.");

            RuleFor(x => x.Colour)
                .NotNull().WithMessage("Item name is required.")
                .NotEmpty().WithMessage("Item name is required.")
                .MaximumLength(100).WithMessage("Item name must not exceed 100 characters.");

            RuleFor(x => x.BrandName)
                .NotNull().WithMessage("Brand name is required.")
                .NotEmpty().WithMessage("Brand name is required.")
                .MaximumLength(100).WithMessage("Brand name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description is required.")
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
