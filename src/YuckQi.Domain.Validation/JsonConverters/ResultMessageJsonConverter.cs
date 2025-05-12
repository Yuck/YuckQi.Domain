using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YuckQi.Domain.Validation.JsonConverters
{
    public class ResultMessageJsonConverter : JsonConverter<ResultMessage>
    {
        public override ResultMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var result = value != null ? new ResultMessage(value) : null;

            return result;
        }

        public override void Write(Utf8JsonWriter writer, ResultMessage value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
