namespace RoomsEnglish.Domain.Models;

public class Room
{
    public string Name { get; set; }

    public Room(string name)
    {
        Name = name;
    }
}
