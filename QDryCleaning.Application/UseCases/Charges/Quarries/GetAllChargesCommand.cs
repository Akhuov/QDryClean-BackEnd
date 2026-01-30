using MediatR;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Charges.Quarries
{
    public class GetAllChargesCommand : IRequest<ApiResponse<List<ChargeDto>>>
    {
    }
}
