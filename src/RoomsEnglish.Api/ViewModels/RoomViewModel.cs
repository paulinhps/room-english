namespace RoomsEnglish.Api.ViewModels;

public class RoomViewModel
{
    public string Name { get; set; }

    public RoomViewModel(string name)
    {
        Name = name;
    }
}