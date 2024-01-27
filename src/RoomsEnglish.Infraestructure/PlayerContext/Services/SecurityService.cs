using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.UserContext.Entities;
using RoomsEnglish.Infraestructure.PlayerContext.Extensions;
using RoomsEnglish.Infraestructure.Security;

namespace RoomsEnglish.Infraestructure.PlayerContext.Services;

public sealed class SecurityService : ISecurityService
{
    public string GenerateHash(string plainPassword)
     => SecretHasher.Hash(plainPassword);

    public Password GeneratePassword(string textPlain)
     => Password.Create(textPlain, this);

    public string GenerateToken(IApplicationUser user)
    {
        JwtSecurityTokenHandler tokenHandler = new();

        //FIXME: hardcodedenvironment variable
        string key = "YavNE4QUboZXTdk8dUiFQVf1MCrnd9X2";

        SymmetricSecurityKey securityKey = new(Encoding.ASCII.GetBytes(key));
        ClaimsIdentity claimsIdentity = user.GetClaimsIdentity();

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddHours(8), // FIXME: hardcoded environment variable
            SigningCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public bool IsValidUser(IApplicationUser? user, string textPlain)
    {
        if (user is null) return false;

        return SecretHasher.Verify(textPlain, user.Password);
    }

}
