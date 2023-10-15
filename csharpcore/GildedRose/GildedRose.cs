using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly IList<UpdateStrategyBase> strategies = new List<UpdateStrategyBase>
    {
        new AgedBrieStrategy(),
        new BackstagePassesStrategy(),
        new SulfurasStrategy(),
        new ConjuredStrategy(),
        new DefaultStrategy()
    };

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updateStrategy = strategies.First(us => us.CanHandle(item));

            updateStrategy.Handle(item);
        }
    }
}