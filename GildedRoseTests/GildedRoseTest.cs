using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private IList<Item> _items = new List<Item>
    {
        new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
        new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
        new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
        new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
    };

    [Fact]
    public void UpdateItems_ShouldCallCreateUpdateStrategyAndUpdateItem()
    {
        // Arrange
        var mockFactory = Substitute.For<IUpdateStrategyFactory>();
        var mockStrategy = Substitute.For<IUpdateStrategy>();
        mockFactory.CreateUpdateStrategy(Arg.Any<Item>()).Returns(mockStrategy);

        GildedRose app = new GildedRose(_items, mockFactory);

        // Act
        app.UpdateItems();

        // Assert
        mockFactory.Received().CreateUpdateStrategy(Arg.Any<Item>());
        mockStrategy.Received().UpdateItem(Arg.Any<Item>());
    }
}
