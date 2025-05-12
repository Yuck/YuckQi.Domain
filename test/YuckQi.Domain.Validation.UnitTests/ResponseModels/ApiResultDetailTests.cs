using NUnit.Framework;
using System.Text.Json;
using YuckQi.Domain.Validation.JsonConverters;
using YuckQi.Domain.Validation.ResponseModels;

namespace YuckQi.Domain.Validation.UnitTests.ResponseModels
{
    public class ApiResultDetailTests
    {
        [Test]
        public void ResultDetail_CanBeDeserialized_ToApiResultDetail()
        {
            var message = "a test message";
            var code = "a test code";
            var property = "property";
            var type = ResultType.Warning;
            var detail = new ResultDetail(message, code, property, type);
            var options = new JsonSerializerOptions { Converters = { new ResultCodeJsonConverter(), new ResultMessageJsonConverter() } };
            var json = JsonSerializer.Serialize(detail, options);
            var response = JsonSerializer.Deserialize<ApiResultDetail>(json, options);

            Assert.That(response, Is.Not.Null);
            Assert.That(response!.Message, Is.EqualTo(message));
            Assert.That(response!.Code, Is.EqualTo(code));
            Assert.That(response!.Property, Is.EqualTo(property));
            Assert.That(response!.Type, Is.EqualTo(type));
        }
    }
}
