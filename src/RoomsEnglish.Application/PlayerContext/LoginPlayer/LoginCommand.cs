using MediatR;

namespace RoomsEnglish.Application.PlayerContext.LoginPlayer;

public class LoginCommand : IRequest<LoginResult>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}