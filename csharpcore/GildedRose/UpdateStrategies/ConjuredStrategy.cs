

namespace GildedRoseKata
{
    class ConjuredStrategy : UpdateStrategyBase
    {
        private const string ItemName = "Conjured Mana Cake";

        public override bool CanHandle(Item item)
        {
            return item.Name == ItemName;
        }

        protected override void UpdateQuality(Item item)
        {
            DecrementQuality(item);
            DecrementQuality(item);
        }
    }
}

