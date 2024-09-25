using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests.Strategies;

public class UpdateAgedBrieTests
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 5)]
    [InlineData(1, 1)]
    public void UpdateAgedBrie_QualityIncreasesByOne_WhenItemIsAgedBrie(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellIn = sellIn - 1;
        var expectedQuality = quality + 1;
        Items[0].Should().BeEquivalentTo(new { Name = "Aged Brie", SellIn = expectedSellIn, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    public void UpdateAgedBrie_ShouldIncreaseQualityTwiceAsFast_WhenItemIsAgedBrieAndSellInIsLessThanZero(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality + 2;
        Items[0].Should().BeEquivalentTo(new { Name = "Aged Brie", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(10, 50)]
    [InlineData(5, 49)]
    [InlineData(-2, 49)]
    public void UpdateAgedBrie_ShouldNotHaveQualityMoreThanFifthy_WhenItemIsAgedBrie(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = 50;
        Items[0].Should().BeEquivalentTo(new { Name = "Aged Brie", SellIn = expectedSellin, Quality = expectedQuality });
    }
}
