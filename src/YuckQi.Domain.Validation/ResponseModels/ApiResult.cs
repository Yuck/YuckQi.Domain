using System.Collections.Generic;

namespace YuckQi.Domain.Validation.ResponseModels
{
    public class ApiResult
    {
        public IReadOnlyCollection<ApiResultDetail> Detail { get; set; } = new List<ApiResultDetail>();
    }

    public class ApiResult<T> : ApiResult
    {
        public T? Content { get; set; }
    }
}
