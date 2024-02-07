namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public class PlayerViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
}