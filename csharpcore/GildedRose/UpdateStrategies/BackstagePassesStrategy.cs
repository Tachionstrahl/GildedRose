

namespace GildedRoseKata
{
    class BackstagePassesStrategy : UpdateStrategyBase
    {
        private const string ItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const int DaysWithinQualityIncrementsTwofold = 10;
        private const int DaysWithinQualityIncrementsThreefold = 5;


        public override bool CanHandle(Item item)
        {
            return item.Name == ItemName;
        }

        protected override void UpdateQuality(Item item)
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
    }
}

