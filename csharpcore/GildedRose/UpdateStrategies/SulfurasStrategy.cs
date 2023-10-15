

namespace GildedRoseKata
{
    class SulfurasStrategy : UpdateStrategyBase
    {
        private const string ItemName = "Sulfuras, Hand of Ragnaros";

        public override bool CanHandle(Item item)
        {
            return item.Name == ItemName;
        }

        protected override void UpdateSellIn(Item item)
        {
            return;
        }

        protected override void UpdateQuality(Item item)
        {
            return;
        }
    }
}

