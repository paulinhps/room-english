
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public class ApplicationUser : Player, IApplicationUser
{
    public Email Email { get; private set; }
    public string Password { get; private set; }
    
    public ApplicationUser(Email email, string password, string name, int level, int experience) : base(name, level, experience)
    {
        Email = email;
        Password = password;
    }
}
