namespace RoomsEnglish.Domain.SharedContext.Entities;

public abstract class EntityBase<TIndetifier>
{
    public TIndetifier Id { get; set; }

    protected EntityBase(TIndetifier id)
    {
        Id = id;
    }
}