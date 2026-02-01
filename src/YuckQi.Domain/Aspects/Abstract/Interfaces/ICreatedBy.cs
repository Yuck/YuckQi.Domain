namespace YuckQi.Domain.Aspects.Abstract.Interfaces;

public interface ICreatedBy<TIdentity>
{
    TIdentity CreatedBy { get; set; }
}
