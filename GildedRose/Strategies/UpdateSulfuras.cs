using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;
using static GildedRoseKata.GildedRoseConstants;

namespace GildedRoseKata.Strategies;

public class UpdateSulfuras : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        item.Quality = Items.LegendaryQuality;
        return;
    }
}
