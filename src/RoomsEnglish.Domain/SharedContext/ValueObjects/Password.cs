using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.SharedContext.ValueObjects;

public class Password : ValueObject
{
    public string Hash { get; } = null!;

    private Password(string hash)
    {
        Hash = hash;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
    }

    public static Password Create(string plainPassword, ISecurityService securityService)
    => new(securityService.GenerateHash(plainPassword));

}