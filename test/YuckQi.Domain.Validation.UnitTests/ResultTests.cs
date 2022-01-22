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
        var hasNotFoundResultCode = result.HasResultCode(ResultCode.NotFound);

        Assert.IsTrue(hasNotFoundResultCode);
    }

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
