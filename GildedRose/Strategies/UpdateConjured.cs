using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;

namespace GildedRoseKata.Strategies;

public class UpdateConjured : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        item.Quality -= 2;
        if (item.SellIn <= 0)
        {
            item.Quality -= 2;
        }
        item.SellIn -= 1;
    }
}