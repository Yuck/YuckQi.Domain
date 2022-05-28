namespace YuckQi.Domain.Entities.Abstract;

public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier> where TIdentifier : struct
{
    public TIdentifier Identifier { get; set; }
}
