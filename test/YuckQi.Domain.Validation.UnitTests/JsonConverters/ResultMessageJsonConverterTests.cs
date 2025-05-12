using NUnit.Framework;
using System;
using System.Text.Json;
using YuckQi.Domain.Validation.JsonConverters;

namespace YuckQi.Domain.Validation.UnitTests.JsonConverters
{
    public class ResultMessageJsonConverterTests
    {
        public record Example(ResultMessage M);

        [SetUp]
        public void Setup() { }

        [Test]
        public void ResultMessage_CanDeserialize_FromJson()
        {
            var value = "something is wrong";
            var json = $"{{\"M\":\"{value}\"}}";
            var options = new JsonSerializerOptions { Converters = { new ResultMessageJsonConverter() } };
            var example = JsonSerializer.Deserialize<Example>(json, options);

            Assert.That(example, Is.Not.Null);
            Assert.That(example, Is.EqualTo(new Example(new ResultMessage($"{value}"))));
        }

        [Test]
        public void ResultMessage_CanSerialize_ToJson()
        {
            var value = Guid.NewGuid();
            var example = new Example(new ResultMessage($"{value}"));
            var options = new JsonSerializerOptions { Converters = { new ResultMessageJsonConverter() } };
            var json = JsonSerializer.Serialize(example, options);

            Assert.That(json, Is.Not.Null);
            Assert.That(json, Is.EqualTo($"{{\"M\":\"{value}\"}}"));
        }
    }
}
