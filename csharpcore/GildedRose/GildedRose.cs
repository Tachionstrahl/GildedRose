using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string NameSulfuras = "Sulfuras, Hand of Ragnaros";
    private const string NameAgedBrie = "Aged Brie";
    private const string NameBackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const int DaysWithinQualityIncrementsTwofold = 10;
    private const int DaysWithinQualityIncrementsThreefold = 5;
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (IsLegendary(item))
            {
                continue;
            }

            item.SellIn--;

            switch (item.Name)
            {
                case NameBackstagePasses:
                    HandleBackstagePasses(item);
                    break;
                case NameAgedBrie:
                    HandleAgedBrie(item);
                    break;
                default:
                    DecrementQuality(item);
                    if (HasSellDatePassed(item))
                        DecrementQuality(item);
                    break;
            }
        }
    }

    private static void HandleAgedBrie(Item item)
    {
        IncrementQuality(item);
        if (HasSellDatePassed(item))
            IncrementQuality(item);
    }

    private static void HandleBackstagePasses(Item item)
    {
        if (HasSellDatePassed(item))
        {
            item.Quality = 0;
            return;
        }
        IncrementQuality(item);

        if (item.SellIn < DaysWithinQualityIncrementsTwofold)
        {
            IncrementQuality(item);
        }

        if (item.SellIn < DaysWithinQualityIncrementsThreefold)
        {
            IncrementQuality(item);

        }

    }

    private static bool IsLegendary(Item item)
    {
        return item.Name == NameSulfuras;
    }

    private static bool HasSellDatePassed(Item item)
    {
        return item.SellIn < 0;
    }

    private static void IncrementQuality(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }

    private static void DecrementQuality(Item item)
    {
        if (item.Quality > 0)
            item.Quality--;
    }
}