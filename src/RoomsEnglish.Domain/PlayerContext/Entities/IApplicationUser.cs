using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.PlayerContext.Entities;

public interface IApplicationUser
{
    public Guid Id { get; }
    Email Email { get; }
    string Password { get; }
    string Name { get; }
}