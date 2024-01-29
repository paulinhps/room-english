namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;

public class PlayerResult
{
    public Guid Id { get; set; }

    public bool Success => !Errors.Any();
    public string? Message { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
