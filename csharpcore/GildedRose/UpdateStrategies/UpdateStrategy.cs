namespace GildedRoseKata
{
    public abstract class UpdateStrategyBase
    {

        public abstract bool CanHandle(Item item);

        public void Handle(Item item)
        {
            UpdateSellIn(item);
            UpdateQuality(item);
        }

        protected virtual void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        protected abstract void UpdateQuality(Item item);

        protected static bool HasSellDatePassed(Item item)
        {
            return item.SellIn < 0;
        }

        protected static void IncrementQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;
        }

        protected static void DecrementQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality--;
        }
    }
}

