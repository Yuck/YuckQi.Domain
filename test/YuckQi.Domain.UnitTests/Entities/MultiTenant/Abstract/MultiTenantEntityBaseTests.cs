using System;
using NUnit.Framework;
using YuckQi.Domain.Entities.MultiTenant.Abstract;

namespace YuckQi.Domain.UnitTests.Entities.MultiTenant.Abstract;

public class MultiTenantEntityBaseTests
{
    private class MultiTenantEntity : MultiTenantEntityBase<Guid, String> { }

    [SetUp]
    public void Setup() { }

    [Test]
    public void MultiTenantEntityBase_GetTenantIdentifier_HasExpectedValue()
    {
        var identifier = Guid.NewGuid().ToString("D").ToUpperInvariant();
        var entity = new MultiTenantEntity { Identifier = Guid.NewGuid(), TenantIdentifier = identifier };

        Assert.That(entity.TenantIdentifier, Is.EqualTo(identifier));
    }

    [Test]
    public void MultiTenantEntityBase_WithDifferentTenantIdentifier_IsNotValid()
    {
        var identifier = Guid.NewGuid().ToString("D").ToUpperInvariant();
        var entity = new MultiTenantEntity();

        Assert.That(entity.IsValidTenant(identifier), Is.False);
    }

    [Test]
    public void MultiTenantEntityBase_WithSameTenantIdentifier_IsValid()
    {
        var identifier = Guid.NewGuid().ToString("D").ToUpperInvariant();
        var entity = new MultiTenantEntity { Identifier = Guid.NewGuid(), TenantIdentifier = identifier };

        Assert.That(entity.IsValidTenant(identifier), Is.True);
    }
}
