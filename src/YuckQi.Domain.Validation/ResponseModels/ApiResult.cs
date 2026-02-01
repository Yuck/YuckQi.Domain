using System.Collections.Generic;

namespace YuckQi.Domain.Validation.ResponseModels
{
    public record ApiResult
    {
        public IReadOnlyCollection<ApiResultDetail> Detail { get; set; } = [];
    }

    public record ApiResult<T> : ApiResult
    {
        public T? Content { get; set; }
    }
}
