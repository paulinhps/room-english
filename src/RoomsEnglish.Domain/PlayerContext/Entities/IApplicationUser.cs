using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.UserContext.Entities;

public interface IApplicationUser
{
    public Guid Id { get; }
    Email Email { get; }
    string Password { get; }
    string Name { get; }
}