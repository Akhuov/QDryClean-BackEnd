using QDryClean.Application.Common.Errors;

namespace QDryClean.Application.Common.Exceptions
{
    public class InvalidLoginOrPasswordException : BaseException
    {
        public InvalidLoginOrPasswordException(string message) : base(message, ErrorCodes.InvalidLoginOrPassword) { }
    }
}
