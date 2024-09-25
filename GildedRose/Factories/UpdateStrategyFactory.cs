using GildedRoseKata.Models;
using GildedRoseKata.Strategies;
using GildedRoseKata.Strategies.Interfaces;
using static GildedRoseKata.GildedRoseConstants;

namespace GildedRoseKata.Factories;

public class UpdateStrategyFactory : IUpdateStrategyFactory
{
    public IUpdateStrategy CreateUpdateStrategy(Item item)
    {
        string normalizedItemName = item.Name.ToLower().Trim();

        if (normalizedItemName.Contains(Items.AgedBrie.ToLower()) || normalizedItemName == Items.AgedBrie.ToLower())
        {
            return new UpdateAgedBrie();
        }
        else if (normalizedItemName.Contains(Items.BackstagePasses.ToLower()) || normalizedItemName == Items.BackstagePasses.ToLower())
        {
            return new UpdateBackStagePasses();
        }
        else if (normalizedItemName.Contains(Items.Sulfuras.ToLower()) || normalizedItemName == Items.Sulfuras.ToLower())
        {
            return new UpdateSulfuras();
        }
        else if (normalizedItemName.Contains(Items.Conjured.ToLower()) || normalizedItemName == Items.Conjured.ToLower())
        {
            return new UpdateConjured();
        }
        else
        {
            return new UpdateStandardItem();
        }
    }
}
