using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class ApplicationResponse
{
    public IEnumerable<Error>? Errors { get; init; }

    public ApplicationResponse()
    {

    }
    protected ApplicationResponse(EResponseType responseType, string message, params Error[] errors)
    {
        ResponseType = responseType;
        Message = message;
        Errors = errors;
    }
    public string? Message { get; init; }
    public virtual bool Success => Errors?.Any() is false;
    public EResponseType ResponseType { get; init; }


}