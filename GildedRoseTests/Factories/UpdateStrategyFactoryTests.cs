using System;
using FluentAssertions;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using GildedRoseKata.Strategies;
using Xunit;

namespace GildedRoseTests.Factories;
public class UpdateStrategyFactoryTests
{
    [Theory]
    [InlineData("Aged Brie", typeof(UpdateAgedBrie))]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(UpdateBackStagePasses))]
    [InlineData("Sulfuras, Hand of Ragnaros", typeof(UpdateSulfuras))]
    [InlineData("Conjured Mana Cake", typeof(UpdateConjured))]
    [InlineData("Elixir of the Mongoose", typeof(UpdateStandardItem))]
    [InlineData("Dexterity Vest", typeof(UpdateStandardItem))]
    public void CreateUpdateStrategy_WhenGivenItem_ShouldReturnCorrectConcreteUpdateStrategyType(string itemName, Type expectedType)
    {
        // Arrange
        var factory = new UpdateStrategyFactory();
        var item = new Item { Name = itemName };

        // Act
        var result = factory.CreateUpdateStrategy(item);

        // Assert
        result.Should().BeOfType(expectedType);
    }
}
