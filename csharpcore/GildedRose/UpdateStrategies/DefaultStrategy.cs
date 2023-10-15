

namespace GildedRoseKata
{
    class DefaultStrategy : UpdateStrategyBase
    {
        public override bool CanHandle(Item item)
        {
            return true;
        }

        protected override void UpdateQuality(Item item)
        {
            DecrementQuality(item);
            if (HasSellDatePassed(item))
                DecrementQuality(item);
        }
    }
}

