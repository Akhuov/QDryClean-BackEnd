using FluentValidation;

namespace QDryClean.Application.UseCases.Customers.Querries.GetAll
{
    public class GetAllCustomersQueryValidator : AbstractValidator<GetAllCustomersQuery>
    {
        public GetAllCustomersQueryValidator()
        {
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
