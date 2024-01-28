namespace RoomsEnglish.Domain.Models;

public class Player
{
    const int QtPointsForLeveling = 100;

    public string Name { get; set; }
    public int Level => (int)(Experience / QtPointsForLeveling);
    public long Experience { get; set; } = 0;

    public Player(string name, long experience)
    {
        Name = name;
        Experience = experience;
    }
}
