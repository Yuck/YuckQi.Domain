using NUnit.Framework;
using System.Linq;
using System.Text.Json;
using YuckQi.Domain.Validation.JsonConverters;
using YuckQi.Domain.Validation.ResponseModels;

namespace YuckQi.Domain.Validation.UnitTests.ResponseModels
{
    public class ApiResultTests
    {
        [Test]
        public void Result_CanBeDeserialized_ToApiResult()
        {
            var message = "a test message";
            var code = "a test code";
            var property = "property";
            var type = ResultType.Warning;
            var detail = new ResultDetail(message, code, property, type);
            var content = "this is some test content";
            var result = new Result<string>(content, [detail]);
            var options = new JsonSerializerOptions { Converters = { new ResultCodeJsonConverter(), new ResultMessageJsonConverter() } };
            var json = JsonSerializer.Serialize(result, options);
            var response = JsonSerializer.Deserialize<ApiResult<string>>(json, options);

            Assert.That(response, Is.Not.Null);
            Assert.That(response!.Content, Is.Not.Null);
            Assert.That(response!.Content, Is.EqualTo(content));
            Assert.That(response!.Detail, Is.Not.Null);
            Assert.That(response!.Detail, Is.Not.Empty);
            Assert.That(response!.Detail, Has.Count.EqualTo(1));
            Assert.That(response!.Detail, Has.Exactly(1).Matches<ApiResultDetail>(t => t.Message == message));
            Assert.That(response!.Detail, Has.Exactly(1).Matches<ApiResultDetail>(t => t.Code == code));
            Assert.That(response!.Detail, Has.Exactly(1).Matches<ApiResultDetail>(t => t.Property == property));
            Assert.That(response!.Detail, Has.Exactly(1).Matches<ApiResultDetail>(t => t.Type == type));
        }
    }
}
