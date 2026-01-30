using MediatR;
using QDryClean.Application.Common.Responses;

namespace QDryClean.Application.UseCases.Charges.Commands
{
    public class SoftDeleteChargeCommand : IRequest<ApiResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
