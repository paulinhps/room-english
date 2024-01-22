using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.UserContext.Entities;

public sealed class SecurityService : ISecurityService
{
    public Task<string> GetAuthToken(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public bool IsValidUser(ApplicationUser? user)
    {
        if(user is null) return false;

        string encryptPassword = GetEncriptPassword(user.Password);

        return encryptPassword.Equals(user.Password);
    }

    private string GetEncriptPassword(string password)
    {
        throw new NotImplementedException();
    }
}