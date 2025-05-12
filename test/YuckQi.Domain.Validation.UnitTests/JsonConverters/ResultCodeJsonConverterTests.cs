using NUnit.Framework;
using System;
using System.Text.Json;
using YuckQi.Domain.Validation.JsonConverters;

namespace YuckQi.Domain.Validation.UnitTests.JsonConverters
{
    public class ResultCodeJsonConverterTests
    {
        public record Example(ResultCode A);

        [SetUp]
        public void Setup() { }

        [Test]
        public void ResultCode_CanDeserialize_FromJson()
        {
            var value = Guid.NewGuid();
            var json = $"{{\"A\":\"{value}\"}}";
            var options = new JsonSerializerOptions { Converters = { new ResultCodeJsonConverter() } };
            var example = JsonSerializer.Deserialize<Example>(json, options);

            Assert.That(example, Is.Not.Null);
            Assert.That(example, Is.EqualTo(new Example(new ResultCode($"{value}"))));
        }

        [Test]
        public void ResultCode_CanSerialize_ToJson()
        {
            var value = Guid.NewGuid();
            var example = new Example(new ResultCode($"{value}"));
            var options = new JsonSerializerOptions { Converters = { new ResultCodeJsonConverter() } };
            var json = JsonSerializer.Serialize(example, options);

            Assert.That(json, Is.Not.Null);
            Assert.That(json, Is.EqualTo($"{{\"A\":\"{value}\"}}"));
        }
    }
}
