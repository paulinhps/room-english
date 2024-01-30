namespace RoomsEnglish.Domain.SharedContext.Models;

public class Notification(string key, string message)
{
    public string Key { get; set; } = key;
    public string Message { get; set; } = message;
}