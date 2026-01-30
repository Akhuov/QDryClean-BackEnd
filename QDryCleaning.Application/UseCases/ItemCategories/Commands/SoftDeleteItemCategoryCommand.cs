using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.ItemCategories.Commands
{
    public class SoftDeleteItemCategoryCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
