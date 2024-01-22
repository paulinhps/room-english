namespace RoomsEnglish.Application.AccountContext.LoginIn;

public class AuthUserResult
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string? AuthToken { get; set; }

    public bool Success => !Errors.Any();
    public string? Message { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<String>();
}
