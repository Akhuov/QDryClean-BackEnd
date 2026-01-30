using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Items.Querries
{
    public class GetByIdItemQuerry : IRequest<ApiResponse<ItemDto>>
    {
        public int Id { get; set; }
    }
}