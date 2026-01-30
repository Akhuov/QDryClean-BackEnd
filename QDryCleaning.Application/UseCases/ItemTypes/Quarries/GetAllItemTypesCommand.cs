using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Quarries
{
    public class GetAllItemTypesCommand : IRequest<ApiResponse<List<ItemTypeDto>>>
    {
    }
}
