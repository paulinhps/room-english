
using RoomsEnglish.Domain.SharedContext.Entities;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public abstract class ApplicationUser : Entity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }
    
    protected ApplicationUser(string name, Email email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
