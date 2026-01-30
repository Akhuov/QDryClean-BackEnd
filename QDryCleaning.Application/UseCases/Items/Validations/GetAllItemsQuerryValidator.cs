using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Items.Querries;

namespace QDryClean.Application.UseCases.Items.Validations
{
    public class GetAllItemsQuerryValidator
        : AbstractValidator<GetAllItemsQuerry>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetAllItemsQuerryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x)
                .NotNull().WithMessage("Request cannot be null")
                .MustAsync(async (command, id, cancellationToken) =>
                {
                    return await _dbContext.Items.AnyAsync(c => c.DeletedAt == null && c.DeletedBy == null, cancellationToken);
                })
                .WithMessage("Item Types not found!"); ;
        }
    }
}
