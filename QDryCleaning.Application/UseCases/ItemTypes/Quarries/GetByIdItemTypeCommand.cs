using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Quarries
{
    public class GetByIdItemTypeCommand : IRequest<ApiResponse<ItemTypeDto>>
    {
        public int Id { get; set; }
    }
}
