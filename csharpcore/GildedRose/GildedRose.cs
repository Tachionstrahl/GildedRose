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
            switch (item.Name)
            {
                case NameBackstagePasses:
                    IncrementQuality(item);

                    if (item.SellIn <= DaysWithinQualityIncrementsTwofold)
                    {
                        IncrementQuality(item);
                    }

                    if (item.SellIn <= DaysWithinQualityIncrementsThreefold)
                    {
                        IncrementQuality(item);

                    }
                    break;
                case NameAgedBrie:
                    IncrementQuality(item);
                    break;
                default:
                    DecrementQuality(item);
                    break;
            }

            if (item.Name != NameSulfuras)
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                if (item.Name == NameAgedBrie)
                {
                    IncrementQuality(item);
                }
                else if (item.Name == NameBackstagePasses)
                {
                    item.Quality = 0;
                }
                else
                {
                    DecrementQuality(item);
                }

            }
        }
    }

    private static void IncrementQuality(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }

    private static void DecrementQuality(Item item)
    {
        if (item.Quality > 0 && item.Name != NameSulfuras)
            item.Quality--;
    }
}