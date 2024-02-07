using System.Security.Claims;

using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Infraestructure.PlayerContext.Extensions;

public static class ApplicationUserExtensions
{
    public static ClaimsIdentity GetClaimsIdentity(this IApplicationUser user)
    => new ClaimsIdentity(new[
        ] {
            new Claim(ClaimTypes.NameIdentifier, user.Email.ToString()!),
            new Claim(AppClaimTypes.PlayerId, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, Roles.Player)
        });
}
