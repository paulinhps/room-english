using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Application.SharedContext.UseCases;

public abstract class ApplicationResponse
{
    public IEnumerable<Error> Errors { get; set; }
    protected ApplicationResponse(EResponseType responseType, string message, params Error[] errors)
    {
        ResponseType = responseType;
        Message = message;
        Errors = errors;
    }
    public string? Message { get; set; }
    public virtual bool Success => !Errors.Any();
    public EResponseType ResponseType { get; private set; }

    public ApplicationResponse HasResponseType(EResponseType responseType)
    {
        ResponseType = responseType;

        return this;
    }
}
