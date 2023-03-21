using System;
using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultDetailTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void ResultDetail_NotFound_HasNotFoundResultCode()
    {
        var detail = ResultDetail.NotFound<Object, Guid>(Guid.NewGuid());

        Assert.That(detail.Code, Is.EqualTo(ResultCode.NotFound));
    }

    [Test]
    public void ResultDetail_WithProperty_HasMatchingPropertyName()
    {
        var detail = new ResultDetail("thing missing", property: "property");

        Assert.That(detail.Property, Is.EqualTo("property"));
    }

    [Test]
    public void ResultDetail_Message_HasMatchingValue()
    {
        var message = "this is a problem";
        var detail = new ResultDetail(message);

        Assert.That((String) detail.Message, Is.EqualTo(message));
    }
}
