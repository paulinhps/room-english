namespace RoomsEnglish.Api.ViewModels;

public class PlayerViewModel
{
    public string Name { get; set; }

    public PlayerViewModel(string name)
    {
        Name = name;
    }
}