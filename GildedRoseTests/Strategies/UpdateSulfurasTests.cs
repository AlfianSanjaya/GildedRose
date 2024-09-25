using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests.Strategies;

public class UpdateSulfurasTests
{
    [Theory]
    [InlineData(0, 80)]
    [InlineData(-1, 80)]
    [InlineData(1, 80)]
    public void UpdateSulfuras_ShouldNotUpdateAnything_WhenItemIsSulfuras(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        Items[0].Should().BeEquivalentTo(new { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality });
    }

    [Fact]
    public void UpdateSulfuras_ShouldAlwaysHaveQualityOf80_WhenItemIsSulfuras()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 79 } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        Items[0].Should().BeEquivalentTo(new { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
    }
}
