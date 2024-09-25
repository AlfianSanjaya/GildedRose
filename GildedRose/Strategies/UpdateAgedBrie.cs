using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;
using static GildedRoseKata.GildedRoseConstants;

namespace GildedRoseKata.Strategies;

public class UpdateAgedBrie : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        item.SellIn -= 1;
        if (item.Quality < Items.MaxQuality)
        {
            item.Quality += 1;
            if (item.SellIn < 0 && item.Quality < Items.MaxQuality)
            {
                item.Quality += 1;
            }
        }
    }
}
