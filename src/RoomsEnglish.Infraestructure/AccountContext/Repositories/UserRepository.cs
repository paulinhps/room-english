using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Infraestructure.AccountContext.Repositories;

public class UserRepository : IUserRepository
{
    public Task<ApplicationUser> FindUserByEmailAsync(string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}