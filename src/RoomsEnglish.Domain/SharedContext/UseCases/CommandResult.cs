using RoomsEnglish.Domain.SharedContext.Models;

namespace RoomsEnglish.Domain.SharedContext.UseCases;

public abstract class CommandResult
{
    public IEnumerable<Error> Errors { get; set; }
    protected CommandResult(params Error[] errors)
    {
        Errors = errors;
    }
    public string? Message { get; set; }
    public bool Success => !Errors.Any();
}
