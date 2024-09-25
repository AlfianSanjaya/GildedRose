using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests.Strategies;

public class UpdateStandardItemTests
{
    [Theory]
    [InlineData(100)]
    [InlineData(99)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-99)]
    public void UpdateStandardItem_ShouldNotDecreaseQuality_WhenQualityIsZero(int sellIn)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = 0 } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act  
        app.UpdateItems();

        // Assert
        var expectedSellIn = sellIn - 1;
        var expectedQuality = 0;
        Items[0].Should().BeEquivalentTo(new { Name = "foo", SellIn = expectedSellIn, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(9, 9)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void UpdateStandardItem_ShouldDecreaseSellInAndQualityByOne_WhenItemIsJustRegular(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellIn = sellIn - 1;
        var expectedQuality = quality - 1;
        Items[0].Should().BeEquivalentTo(new { Name = "foo", SellIn = expectedSellIn, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    [InlineData(-2, 10)]
    [InlineData(-3, 10)]
    public void UpdateStandardItem_ShouldDecreaseQualityTwiceAsFast_WhenSellInIsLessThanZero(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellIn = sellIn - 1;
        var expectedQuality = quality - 2;
        Items[0].Should().BeEquivalentTo(new { Name = "foo", SellIn = expectedSellIn, Quality = expectedQuality });
    }
}
