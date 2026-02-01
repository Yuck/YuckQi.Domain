using NUnit.Framework;
using System;
using System.Text.Json;
using YuckQi.Domain.Validation.JsonConverters;

namespace YuckQi.Domain.Validation.UnitTests.JsonConverters
{
    public class ResultCodeJsonConverterTests
    {
        private readonly JsonSerializerOptions _options = new () { Converters = { new ResultCodeJsonConverter() } };

        public record Example(ResultCode A);

        [SetUp]
        public void Setup() { }

        [Test]
        public void ResultCode_CanDeserialize_FromJson()
        {
            var value = Guid.NewGuid();
            var json = $"{{\"A\":\"{value}\"}}";
            var example = JsonSerializer.Deserialize<Example>(json, _options);

            Assert.That(example, Is.Not.Null);
            Assert.That(example, Is.EqualTo(new Example(new ResultCode($"{value}"))));
        }

        [Test]
        public void ResultCode_CanSerialize_ToJson()
        {
            var value = Guid.NewGuid();
            var example = new Example(new ResultCode($"{value}"));
            var json = JsonSerializer.Serialize(example, _options);

            Assert.That(json, Is.Not.Null);
            Assert.That(json, Is.EqualTo($"{{\"A\":\"{value}\"}}"));
        }
    }
}
