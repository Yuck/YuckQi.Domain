namespace YuckQi.Domain.Aspects.Abstract;

public interface IAudited<TIdentity> : ICreated, IRevised
{
    TIdentity CreatedBy { get; set; }
    TIdentity RevisedBy { get; set; }
}
