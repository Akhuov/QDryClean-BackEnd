using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemCategories.Querries
{
    public class GetAllItemCategoriesQuerry : IRequest<ApiResponse<List<ItemCategoryDto>>> { }
}
