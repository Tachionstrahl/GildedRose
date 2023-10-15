

namespace GildedRoseKata
{
    class AgedBrieStrategy : UpdateStrategyBase
    {
        private const string ItemName = "Aged Brie";

        public override bool CanHandle(Item item) => item.Name == ItemName;

        protected override void UpdateQuality(Item item)
        {
            IncrementQuality(item);
            if (HasSellDatePassed(item))
                IncrementQuality(item);
        }
    }
}

