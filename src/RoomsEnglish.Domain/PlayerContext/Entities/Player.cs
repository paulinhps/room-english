using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public class Player : ApplicationUser
{
    public Player(string name, Email email, string password, int level, int experience) : base(name, email, password)
    {
        Level = level;
        Experience = experience;
    }

    // TODO: vamos utilizar um serviço para calcular Nível baseado na experiência
    // Isso porque vamos criar eventos com gatilhos que vai fazer atualização da sessão
    // quando o player ganhar experiência.
    public int Level { get; private set; }
    public int Experience { get; private set; }
}
