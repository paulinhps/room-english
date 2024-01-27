using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Services;

public interface ISecurityService
{
    string GenerateHash(string plainPassword);
    string GenerateToken(IApplicationUser user);
    bool IsValidUser(IApplicationUser? user, string textPlain);

    Password GeneratePassword(string textPlain);
}