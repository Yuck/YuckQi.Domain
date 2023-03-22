using System;
using NUnit.Framework;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.UnitTests.Entities.Abstract;

public class EntityBaseTests
{
    private class Entity : EntityBase<Guid> { }

    [SetUp]
    public void Setup() { }

    [Test]
    public void EntityBase_GetIdentifier_HasExpectedValue()
    {
        var identifier = Guid.NewGuid();
        var entity = new Entity { Identifier = identifier };

        Assert.That(entity.Identifier, Is.EqualTo(identifier));
    }
}
