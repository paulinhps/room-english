using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Services;

public interface ISecurityService
{
    Task<string> GetAuthToken(ApplicationUser user);
    bool IsValidUser(ApplicationUser? user);
}