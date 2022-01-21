using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultCodeTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void ResultCode_WithSameCode_HasSameHashCode()
    {
        var resultCodeA = new ResultCode("test");
        var hashCodeA = resultCodeA.GetHashCode();
        var resultCodeB = new ResultCode("test");
        var hashCodeB = resultCodeB.GetHashCode();

        Assert.AreEqual(hashCodeA, hashCodeB);
    }
}
