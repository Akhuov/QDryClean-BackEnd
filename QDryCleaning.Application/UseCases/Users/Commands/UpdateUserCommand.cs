using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : UserDto, IRequest<UserDto> { }
}
