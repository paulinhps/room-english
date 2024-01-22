namespace RoomsEnglish.Domain.SharedContext.Entities;
public abstract class Entity : EntityBase<Guid>
{

    public Entity() : this(Guid.NewGuid())
    {
        
    }
    protected Entity(Guid id) : base(id)
    {
    }
}