using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Interfaces;

namespace GildedRoseKata.Factories;

public interface IUpdateStrategyFactory
{
    public IUpdateStrategy CreateUpdateStrategy(Item item);
}
