
namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginPlayerResult(string authToken)
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string AuthToken { get; } = authToken;

}
