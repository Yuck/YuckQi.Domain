namespace YuckQi.Domain.ValueObjects.Abstract
{
    public interface IPage
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}