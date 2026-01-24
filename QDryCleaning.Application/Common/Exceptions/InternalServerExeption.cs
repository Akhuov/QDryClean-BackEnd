using QDryClean.Application.Common.Errors;

namespace QDryClean.Application.Common.Exceptions
{
    public class InternalServerExeption : BaseException
    {
        public InternalServerExeption(string message) : base(message, ErrorCodes.InternalServerError) { }
    }
}
