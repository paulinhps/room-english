using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;

public class QueryResult<T>
{
    public T? Data { get; set; }
    public bool Success => !Errors.Any() && MessageCode < 400;
    public string? Message { get; set; }
    public int MessageCode { get; set; } = 200;
    public IEnumerable<string> Errors { get; set; } = new List<string>();

    public static implicit operator QueryResult<T>(QueryResult<IEnumerable<PlayerViewModel>> v)
    {
        throw new NotImplementedException();
    }

}
