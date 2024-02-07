using RoomsEnglish.Domain.SharedContext.Entities;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.PlayerContext.Entities;

public class Player : Entity, IApplicationUser
{
    public Email Email { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }

    public Player(Email email, string password, string name, int level = 1, int experience = 0)
    {
        Email = email;
        Password = password;
        Name = name;
        Level = level;
        Experience = experience;
    }
}


// TODO: vamos utilizar um serviço para calcular Nível baseado na experiência Isso porque vamos criar eventos com gatilhos que vai fazer atualização da sessão quando o player ganhar experiência.