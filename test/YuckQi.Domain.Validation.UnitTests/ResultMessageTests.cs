using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultMessageTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void ResultMessage_ToString_MatchesOriginalMessage()
    {
        var message = new ResultMessage("this is a test");

        Assert.That(message.ToString(), Is.EqualTo("this is a test"));
    }

    [Test]
    public void ResultMessage_WithNoMessage_IsNotNull()
    {
        var message = new ResultMessage();

        Assert.That(message.ToString(), Is.Not.Null);
    }
}
