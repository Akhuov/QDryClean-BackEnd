using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Orders.Queries;

namespace QDryClean.Application.UseCases.Orders.Validators
{
    public class GetByIdOrderQueryValidator
        : AbstractValidator<GetByIdOrderQuery>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetByIdOrderQueryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Order ID is required.")
                .GreaterThan(0).WithMessage("Order ID must be greater than 0")
                .MustAsync(async (query, id, cancellationToken) =>
                    await _dbContext.Orders.AnyAsync(o => o.Id == id && o.DeletedAt == null && o.DeletedBy == null, cancellationToken)
                ).WithMessage("Order with this ID does not exist");
        }
    }
}
