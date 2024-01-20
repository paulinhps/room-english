
using RoomsEnglish.Domain.SharedContext.Entities;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public class ApplicationUser : Entity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    
    public ApplicationUser(string name, Email email)
    {
        Name = name;
        Email = email;
    }
}