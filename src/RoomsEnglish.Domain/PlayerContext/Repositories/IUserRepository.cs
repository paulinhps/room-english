using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Domain.PlayerContext.Repositories;

public interface IUserRepository
{
    Task<IApplicationUser> FindUserByEmailAsync(string userEmail, CancellationToken cancellationToken);

}