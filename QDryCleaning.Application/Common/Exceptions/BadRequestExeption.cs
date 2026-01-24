using QDryClean.Application.Common.Errors;

namespace QDryClean.Application.Common.Exceptions
{
    public class BadRequestExeption : BaseException
    {
        public BadRequestExeption(string message) : base(message, ErrorCodes.BadRequest) { }
    }
}
