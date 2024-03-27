using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Result_NotFound_HasNotFoundResultCode()
    {
        var detail = new List<ResultDetail> { ResultDetail.NotFound<String, Int32>(1) }.AsReadOnly();
        var result = new Result<String>(detail);

        Assert.That(result.HasResultCode(ResultCode.NotFound), Is.True);
    }

    [Test]
    public void Result_WithErrors_IsNotValid()
    {
        var detail = new List<ResultDetail> { new ("test") };
        var result = new Result<String>("test", detail);

        Assert.That(result.IsValid, Is.False);
    }

    [Test]
    public void Result_WithNoDetail_IsValid()
    {
        var result = new Result<String>("test");

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void Result_WithOnlyWarnings_IsValid()
    {
        var detail = new List<ResultDetail> { new (new ResultMessage("test"), type: ResultType.Warning) };
        var result = new Result<String>("test", detail);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void Result_Content_IsValid()
    {
        var content = Guid.NewGuid().ToString();
        var result = new Result<String>(content);

        Assert.That(result.IsValid, Is.True);
        Assert.That(result.Content, Is.SameAs(content));
    }

    [Test]
    public void Result_NotFound_IsValid()
    {
        var identifier = Guid.NewGuid().ToString();
        var result = Result<String>.NotFound(identifier);
        var errors = result.Detail.Where(t => t.Code == ResultCode.NotFound);

        Assert.That(errors.Count(), Is.EqualTo(1));
    }
}
