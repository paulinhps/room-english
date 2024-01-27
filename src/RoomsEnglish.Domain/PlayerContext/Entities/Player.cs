using RoomsEnglish.Domain.SharedContext.Entities;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public class Player : Entity
{
    public string Name { get; private set; }
    // TODO: vamos utilizar um serviço para calcular Nível baseado na experiência
    // Isso porque vamos criar eventos com gatilhos que vai fazer atualização da sessão
    // quando o player ganhar experiência.
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public Player(string name, int level, int experience)
    {
        Name = name;
        Level = level;
        Experience = experience;
    }

}
