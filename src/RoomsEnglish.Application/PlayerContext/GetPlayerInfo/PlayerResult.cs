namespace RoomsEnglish.Application.PlayerContext.GetPlayerInfo;

public class QueryResult<T>
{
    public IEnumerable<T>? Data { get; set; }
    public bool Success => !Errors.Any() || MessageCode != 200;
    public string? Message { get; set; }
    public int MessageCode { get; set; } = 200;
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
