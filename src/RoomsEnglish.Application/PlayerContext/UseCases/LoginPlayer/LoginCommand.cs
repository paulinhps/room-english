using RoomsEnglish.Application.SharedContext.UseCases;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginCommand : RequestQuery<LoginResult>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

