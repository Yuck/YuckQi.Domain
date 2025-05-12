using System;

namespace YuckQi.Domain.Validation.ResponseModels
{
    public class ApiResultDetail
    {
        public String? Code { get; set; }
        public String? Message { get; set; }
        public String? Property { get; set; }
        public ResultType Type { get; set; }
    }
}
