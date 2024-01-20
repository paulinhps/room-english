namespace RoomsEnglish.Domain.SharedContext.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; set; }

    public Email(string address)
    {
        Address = address;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }

    public static implicit operator Email(string emailAdress) => new(emailAdress);
}