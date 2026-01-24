using Microsoft.AspNetCore.Mvc.ModelBinding;
using QDryClean.Application.Common.Errors;
using QDryClean.Application.Common.Exceptions;

public class InvalidModelStateException : BaseException
{
    public InvalidModelStateException(ModelStateDictionary modelState)
        : base(BuildMessage(modelState), ErrorCodes.BadRequest)
    {
    }

    private static string BuildMessage(ModelStateDictionary modelState)
    {
        return string.Join("; ",
            modelState
                .Where(x => x.Value.Errors.Count > 0)
                .SelectMany(x =>
                    x.Value.Errors.Select(e =>
                        $"{x.Key}: {e.ErrorMessage}"
                    )
                )
        );
    }
}