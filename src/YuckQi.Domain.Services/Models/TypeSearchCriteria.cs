using YuckQi.Domain.Application.Abstract;

namespace YuckQi.Domain.Services.Models
{
    public class TypeSearchCriteria : IPage
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}