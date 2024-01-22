using MediatR;

namespace RoomsEnglish.Application.AccountContext.LoginIn;

public class AuthUserCommand : IRequest<AuthUserResult>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;


}
