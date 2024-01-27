using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Repositories;

public interface IUserRepository
{
    Task<IApplicationUser> FindUserByEmailAsync(string userEmail, CancellationToken cancellationToken);

}