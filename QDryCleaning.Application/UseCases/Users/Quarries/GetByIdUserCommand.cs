using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Users.Quarries
{
    public class GetByIdUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
