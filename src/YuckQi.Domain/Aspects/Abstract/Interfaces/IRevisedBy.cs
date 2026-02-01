namespace YuckQi.Domain.Aspects.Abstract.Interfaces;

public interface IRevisedBy<TIdentity>
{
    TIdentity RevisedBy { get; set; }
}
