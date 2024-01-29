using RoomsEnglish.Domain.SharedContext.Models;
using RoomsEnglish.Domain.SharedContext.UseCases;

namespace RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

public class ErrorCommandResult : CommandResult
{
    public ErrorCommandResult(string message, params Error[] errors) : base(errors)
    {
        Message = message;
    }

}