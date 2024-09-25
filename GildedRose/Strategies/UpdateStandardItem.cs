using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;

namespace GildedRoseKata.Strategies;
public class UpdateStandardItem : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        item.SellIn -= 1;

        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }
}