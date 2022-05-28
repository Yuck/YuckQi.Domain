namespace YuckQi.Domain.Entities.Abstract;

public interface IEntity<TIdentifier> where TIdentifier : struct
{
    TIdentifier Identifier { get; set; }
}
