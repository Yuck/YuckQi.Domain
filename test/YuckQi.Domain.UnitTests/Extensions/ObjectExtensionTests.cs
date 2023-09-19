using System;
using System.Linq;
using NUnit.Framework;
using YuckQi.Domain.Extensions;

namespace YuckQi.Domain.UnitTests.Extensions;

public class ObjectExtensionTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Object_WithSomeNonNullProperties_HasExpectedValue()
    {
        var a = new { a = new Int32?(), b = 1234, c = "hello", d = new Int64?(9999) };
        var result = a.GetNonNullProperties();

        Assert.That(result, Has.Exactly(3).Items);
        Assert.That(result.Select(t => t.Name), Does.Not.Contain("a"));
    }

    [Test]
    public void Objects_WhereOneIsNull_HaveAllPropertyDifferences()
    {
        var a = new { a = 123, b = "test" };
        var result = a.GetDifferencesByProperty(default);

        Assert.That(result, Has.Exactly(2).Items);
    }

    [Test]
    public void Objects_WithDifferentStringValues_HaveOneDifference()
    {
        var a = new { a = 123, b = "test" };
        var b = new { a = 123, b = "hello" };
        var result = a.GetDifferencesByProperty(b);

        Assert.That(result, Has.Exactly(1).Items);
        Assert.That(result.Single().Key.Name, Is.EqualTo(nameof(a.b)));
        Assert.That(result.Single().Value.Item1, Is.EqualTo("test"));
        Assert.That(result.Single().Value.Item2, Is.EqualTo("hello"));
    }
}
