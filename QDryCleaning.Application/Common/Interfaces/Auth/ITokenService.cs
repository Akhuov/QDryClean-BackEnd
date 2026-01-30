using QDryClean.Domain.Enums;

namespace QDryClean.Application.Common.Interfaces.Auth
{
    public interface ITokenService
    {
        string GenerateToken(int id, UserRole role);
    }
}
