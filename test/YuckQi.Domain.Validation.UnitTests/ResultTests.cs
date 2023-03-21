using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Result_NotFound_HasNotFoundResultCode()
    {
        var detail = new List<ResultDetail> { ResultDetail.NotFound<String, Int32>(1), ResultDetail.ConstraintViolation<String, Int32>(1) }.AsReadOnly();
        var result = new Result<String>(detail);

        Assert.That(result.HasResultCode(ResultCode.NotFound), Is.True);
    }

    [Test]
    public void Result_WithErrors_IsNotValid()
    {
        var detail = new List<ResultDetail> { new("test") };
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
        var detail = new List<ResultDetail> { new(new ResultMessage("test"), type: ResultType.Warning) };
        var result = new Result<String>("test", detail);

        Assert.That(result.IsValid, Is.True);
    }
}
