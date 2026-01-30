using FluentValidation;
using QDryClean.Application.UseCases.Charges.Commands;

namespace QDryClean.Application.UseCases.Charges.Validators
{
    public class CreateChargeCommandValidator
        : AbstractValidator<CreateChargeCommand>
    {
        public CreateChargeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Charge Name is required.")
                .MaximumLength(100).WithMessage("Charge Name must not exceed 100 characters.");

            RuleFor(x => x.Cost)
                .NotEmpty().WithMessage("Charge Cost is required.")
                .GreaterThan(0).WithMessage("Charge Cost must be greater than zero.");
        }
    }
}
