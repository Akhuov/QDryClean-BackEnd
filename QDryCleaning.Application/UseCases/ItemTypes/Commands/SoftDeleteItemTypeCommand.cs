using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class SoftDeleteItemTypeCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
