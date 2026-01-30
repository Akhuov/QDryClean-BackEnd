using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.Items.Commands
{
    public class SoftDeleteItemCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
