using System;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.Services.Models
{
    public class TypeSearchCriteria : IPage
    {
        public String Name { get; set; }
        public Int32 PageNumber { get; set; }
        public Int32 PageSize { get; set; }
    }
}
