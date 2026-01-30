using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Customers.Queries;

namespace QDryClean.Application.UseCases.Customers.Validators
{
    public class GetAllCustomersQueryValidator : AbstractValidator<GetAllCustomersQuery>
    {
        IApplicationDbContext _dbContext;
        public GetAllCustomersQueryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x)
                .NotNull().WithMessage("Request cannot be null")
                .MustAsync(async (command, id, cancellationToken) =>
                    {
                        return await _dbContext.Customers.AnyAsync(c => c.DeletedAt == null && c.DeletedBy == null, cancellationToken);
                    })
                .WithMessage("Customers not found!"); ;

            //После реализации пагинации можно раскомментировать эти правила
            //RuleFor(x => x.PageNumber)
            //    .GreaterThan(0).WithMessage("Page number must be greater than 0");

            //RuleFor(x => x.PageSize)
            //    .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100");

            //// Поиск по имени или email
            //RuleFor(x => x.SearchTerm)
            //    .MaximumLength(100).WithMessage("Search term is too long");
        }
    }
}
