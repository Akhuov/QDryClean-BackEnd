using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Users.Quarries
{
    public class GetAllUsersCommand : IRequest<List<UserDto>>
    {
    }
}
