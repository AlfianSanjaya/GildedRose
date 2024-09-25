using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests.Strategies;

public class UpdateBackStagePassesTests
{
    [Theory]
    [InlineData(11, 10)]
    [InlineData(12, 10)]
    [InlineData(13, 10)]
    [InlineData(10, 49)]
    public void UpdateBackstagePasses_ShouldIncreaseQualityByOne_WhenSellInIsMoreThanTen(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality + 1;
        Items[0].Should().BeEquivalentTo(new { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(9, 10)]
    [InlineData(8, 10)]
    [InlineData(7, 10)]
    [InlineData(6, 10)]
    public void UpdateBackstagePasses_ShouldIncreaseByTwo_WhenSellInIsLessThanTen(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality + 2;
        Items[0].Should().BeEquivalentTo(new { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(5, 10)]
    [InlineData(4, 10)]
    [InlineData(3, 10)]
    [InlineData(2, 10)]
    [InlineData(1, 10)]
    public void UpdateBackstagePasses_ShouldIncreaseByThree_WhenSellInIsLessThanFive(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality + 3;
        Items[0].Should().BeEquivalentTo(new { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    [InlineData(-2, 10)]
    public void UpdateBackstagePasses_ShouldSetQualityToZero_WhenSellInIsLessThanZero(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = 0;
        Items[0].Should().BeEquivalentTo(new { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(10, 50)]
    [InlineData(9, 49)]
    [InlineData(4, 48)]
    public void UpdateBackStagePasses_ShouldNotUpdateItem_WhenQualityIsFifty(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = 50;
        Items[0].Should().BeEquivalentTo(new { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = expectedSellin, Quality = expectedQuality });
    }
}
