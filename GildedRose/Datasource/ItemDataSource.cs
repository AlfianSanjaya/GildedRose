﻿using System.Collections.Generic;
using GildedRoseKata.Models;

namespace GildedRoseKata.Datasource;

public class ItemDataSource
{
    public static readonly ItemDataSource Instance = new ItemDataSource();
    public IList<Item> Items { get; set; }
    public ItemDataSource()
    {
        Items = new List<Item>
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
    }
}
