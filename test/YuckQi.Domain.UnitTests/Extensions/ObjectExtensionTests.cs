using System.Linq;
using NUnit.Framework;
using YuckQi.Domain.Extensions;

namespace YuckQi.Domain.UnitTests.Extensions;

public class ObjectExtensionTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Objects_WithDifferentStringValues_HaveOneDifference()
    {
        var a = new { a = 123, b = "test" };
        var b = new { a = 123, b = "hello" };
        var differences = a.GetDifferencesByProperty(b);

        Assert.That(differences, Has.Exactly(1).Items);
        Assert.That(differences.Single().Key.Name, Is.EqualTo(nameof(a.b)));
        Assert.That(differences.Single().Value.Item1, Is.EqualTo("test"));
        Assert.That(differences.Single().Value.Item2, Is.EqualTo("hello"));
    }
}
