using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultCodeTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void ResultCode_WithSameCode_HasSameHashCode()
    {
        var resultCodeA = new ResultCode();
        var hashCodeA = resultCodeA.GetHashCode();
        var resultCodeB = new ResultCode(resultCodeA);
        var hashCodeB = resultCodeB.GetHashCode();

        Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
    }

    [Test]
    public void ResultCode_StringConversion_IsAsExpected()
    {
        var resultCode = new ResultCode("test");

        Assert.That(resultCode.ToString(), Is.EquivalentTo("test"));
    }

    [Test]
    public void ResultCode_Equality_IsAsExpected()
    {
        var resultCodeA = new ResultCode("test");
        var resultCodeB = new ResultCode("test");

        Assert.That(resultCodeA.Equals("test"), Is.True);
        Assert.That(resultCodeA.Equals(resultCodeB), Is.True);
        Assert.That(resultCodeA.Equals(1234), Is.False);
    }

    [Test]
    public void ResultCode_ToString_IsAsExpected()
    {
        var resultCode = new ResultCode("test");

        Assert.That(resultCode.ToString(), Is.EqualTo("test"));
    }
}
