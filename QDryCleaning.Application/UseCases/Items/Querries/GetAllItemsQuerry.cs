using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Items.Querries
{
    public class GetAllItemsQuerry : IRequest<ApiResponse<List<ItemDto>>> { }
}
