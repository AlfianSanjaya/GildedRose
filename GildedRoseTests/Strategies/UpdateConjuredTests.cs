using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests.Strategies;

public class UpdateConjuredTests
{
    [Theory]
    [InlineData(3, 6)]
    [InlineData(2, 4)]
    [InlineData(1, 2)]
    public void UpdateConjured_ShouldDecreaseQualityTwiceAsFast_WhenItemIsConjured(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality - 2;
        Items[0].Should().BeEquivalentTo(new { Name = "Conjured Mana Cake", SellIn = expectedSellin, Quality = expectedQuality });
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 78)]
    [InlineData(-2, 22)]
    public void UpdateConjured_ShouldDecreaseQualityByFour_WhenItemIsConjuredAndSellInIsLessThanZero(int sellIn, int quality)
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items, new UpdateStrategyFactory());

        // Act
        app.UpdateItems();

        // Assert
        var expectedSellin = sellIn - 1;
        var expectedQuality = quality - 4;
        Items[0].Should().BeEquivalentTo(new { Name = "Conjured Mana Cake", SellIn = expectedSellin, Quality = expectedQuality });
    }
}
