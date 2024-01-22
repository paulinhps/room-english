using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser> FindUserByEmailAsync(string userName, CancellationToken cancellationToken);
}