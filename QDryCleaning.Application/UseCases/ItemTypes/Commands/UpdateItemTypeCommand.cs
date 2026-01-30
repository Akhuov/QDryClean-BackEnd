using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class UpdateItemTypeCommand : IRequest<ApiResponse<ItemTypeDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}