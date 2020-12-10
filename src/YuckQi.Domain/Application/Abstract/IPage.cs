namespace YuckQi.Domain.Application.Abstract
{
    public interface IPage
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}