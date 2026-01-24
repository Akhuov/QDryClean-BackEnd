using QDryClean.Application.Common.Errors;

namespace QDryClean.Application.Common.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message, ErrorCodes.NotFound) { }
}
