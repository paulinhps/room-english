
namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginResult(string authToken)
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string AuthToken { get; } = authToken;

}
