using System;
using System.Collections.Generic;
using GildedRoseKata.Datasource;
using GildedRoseKata.Factories;
using GildedRoseKata.Models;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = ItemDataSource.Instance.Items;

            var app = new GildedRose(items, new UpdateStrategyFactory());

            int days = 2;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i < days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateItems();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}