using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultCodeTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void ResultCode_WithSameCode_HasSameHashCode()
    {
        var a = new ResultCode("test");
        var hashCodeA = a.GetHashCode();
        var b = new ResultCode("test");
        var hashCodeB = b.GetHashCode();

        Assert.AreEqual(hashCodeA, hashCodeB);
    }
}
