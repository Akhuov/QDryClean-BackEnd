using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;

namespace QDryClean.Application.UseCases.Orders.Queries.GetById
{
    public class GetByIdOrderQueryValidator
        :AbstractValidator<GetByIdOrderQuery>
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
