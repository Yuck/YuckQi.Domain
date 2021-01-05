﻿using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.Services.Models
{
    public class TypeSearchCriteria : IPage
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}