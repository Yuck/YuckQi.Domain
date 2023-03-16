using System;
using System.Collections.Generic;
using NUnit.Framework;
using YuckQi.Domain.ValueObjects;

namespace YuckQi.Domain.UnitTests.ValueObjects;

public class PageTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Page_Properties_HaveExpectedValues()
    {
        var page = new Page(1, 10);

        Assert.That(page.PageNumber, Is.EqualTo(1));
        Assert.That(page.PageSize, Is.EqualTo(10));
    }

    [Test]
    public void PageOfString_Properties_HaveExpectedValues()
    {
        var items = new HashSet<String> { "abc", "def", "ghi" };
        var page = new Page<String>(items, items.Count, 1, 10);

        Assert.That(page.Items, Contains.Item("abc"));
        Assert.That(page.Items, Contains.Item("def"));
        Assert.That(page.Items, Contains.Item("ghi"));
        Assert.That(page.PageNumber, Is.EqualTo(1));
        Assert.That(page.PageSize, Is.EqualTo(10));
        Assert.That(page.TotalCount, Is.EqualTo(3));
    }
}
