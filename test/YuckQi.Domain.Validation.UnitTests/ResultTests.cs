using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace YuckQi.Domain.Validation.UnitTests;

public class ResultTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Result_WithErrors_IsNotValid()
    {
        var detail = new List<ResultDetail> { new(new ResultCode("test"), new ResultMessage("id")) };
        var result = new Result<String>("test", detail);
        var isValid = result.IsValid;

        Assert.IsFalse(isValid);
    }

    [Test]
    public void Result_WithNoDetail_IsValid()
    {
        var result = new Result<String>("test");
        var isValid = result.IsValid;

        Assert.IsTrue(isValid);
    }

    [Test]
    public void Result_WithOnlyWarnings_IsValid()
    {
        var detail = new List<ResultDetail> { new(new ResultCode("test"), new ResultMessage("id"), type: ResultType.Warning) };
        var result = new Result<String>("test", detail);
        var isValid = result.IsValid;

        Assert.IsTrue(isValid);
    }
}
