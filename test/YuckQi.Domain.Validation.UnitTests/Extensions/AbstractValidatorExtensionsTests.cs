using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using NUnit.Framework;
using YuckQi.Domain.Validation.Extensions;

namespace YuckQi.Domain.Validation.UnitTests.Extensions;

public class AbstractValidatorExtensionsTests
{
    public class StringValidator : AbstractValidator<String>
    {
        public StringValidator()
        {
            RuleFor(t => t.Length).GreaterThan(1).WithMessage("it is too short");
        }
    }

    [SetUp]
    public void Setup() { }

    [Test]
    public void AbstractValidator_GetResultWithValidItem_IsValid()
    {
        var validator = new StringValidator();
        var result = validator.GetResult("hello");

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public async Task AbstractValidator_GetResultAsyncWithValidItem_IsValid()
    {
        var validator = new StringValidator();
        var result = await validator.GetResult("hello", CancellationToken.None);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void AbstractValidator_GetResultWithInvalidItem_HasDetail()
    {
        var validator = new StringValidator();
        var result = validator.GetResult(String.Empty);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Detail, Is.Not.Empty);
    }

    [Test]
    public void AbstractValidator_GetResultWithNullReference_ThrowsException()
    {
        Assert.That(() => AbstractValidatorExtensions.GetResult(null!, String.Empty), Throws.ArgumentNullException);
    }

    [Test]
    public void AbstractValidator_GetResultAsyncWithNullReference_ThrowsException()
    {
        Assert.That(() => AbstractValidatorExtensions.GetResult(null!, String.Empty, CancellationToken.None), Throws.ArgumentNullException);
    }
}
