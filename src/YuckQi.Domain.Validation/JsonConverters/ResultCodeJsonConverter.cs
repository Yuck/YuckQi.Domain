using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YuckQi.Domain.Validation.JsonConverters
{
    public class ResultCodeJsonConverter : JsonConverter<ResultCode>
    {
        public override ResultCode? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var result = value != null ? new ResultCode(value) : null;

            return result;
        }

        public override void Write(Utf8JsonWriter writer, ResultCode value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
