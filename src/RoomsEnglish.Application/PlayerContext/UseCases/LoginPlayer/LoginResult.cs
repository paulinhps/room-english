using RoomsEnglish.Domain.SharedContext.UseCases;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginResult : CommandResult
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string? AuthToken { get; set; }

}
