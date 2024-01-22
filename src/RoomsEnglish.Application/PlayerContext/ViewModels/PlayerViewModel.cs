namespace RoomsEnglish.Application.PlayerContext.ViewModels;

public class PlayerViewModel
{
    public string Name { get; set; }

    public PlayerViewModel(string name)
    {
        Name = name;
    }
}