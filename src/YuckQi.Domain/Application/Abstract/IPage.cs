namespace YuckQi.Domain.Application.Abstract
{
    public interface IPage
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}