using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }

    [Fact]
    public void Should_Decrement_SellIn()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].SellIn);
    }

    [Fact]
    public void Should_Decrement_Quality()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Should_Decrement_Twice_On_Expired()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 2 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }
    [Fact]
    public void Quality_Should_Not_Be_Negative()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Aged_Brie_Should_Increment_Quality()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(2, items[0].Quality);
    }

    [Fact]
    public void Quality_Should_Not_Exceed_Fifty()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_Should_Not_Change()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void Backstage_passes_Quality_Should_Be_Set_To_Zero_After_Concert()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 5 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Backstage_passes_Quality_Should_Increase_By_2_On_10_Or_Less_Days()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 5 } };
        GildedRose app = new GildedRose(items);
        while (items[0].SellIn > 5)
        {
            var currentQuality = items[0].Quality;
            app.UpdateQuality();
            Assert.Equal(currentQuality + 2, items[0].Quality);

        }
    }

    [Fact]
    public void Backstage_passes_Quality_Should_Increase_By_3_On_5_Or_Less_Days()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void Conjured_Should_Decrease_Twofold()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 2 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }



}