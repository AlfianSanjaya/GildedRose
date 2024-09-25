using System.Collections.Generic;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly IUpdateStrategyFactory _updateStrategyFactory;

    public GildedRose(IList<Item> items, IUpdateStrategyFactory updateStrategyFactory)
    {
        _items = items;
        _updateStrategyFactory = updateStrategyFactory;
    }

    public void UpdateItems()
    {
        foreach (Item item in _items)
        {
            IUpdateStrategy updateStrategy = _updateStrategyFactory.CreateUpdateStrategy(item);
            updateStrategy.UpdateItem(item);
        }
    }
}