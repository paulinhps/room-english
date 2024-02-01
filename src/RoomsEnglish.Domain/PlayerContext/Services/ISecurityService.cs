using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Domain.PlayerContext.Services;

public interface ISecurityService
{
    string GenerateHash(string plainPassword);
    string GenerateToken(IApplicationUser user);
    bool IsValidUser(IApplicationUser? user, string textPlain);

    Password GeneratePassword(string textPlain);
}