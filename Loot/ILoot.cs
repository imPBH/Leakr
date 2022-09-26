using Project_CS.Player;

namespace Project_CS.Loot
{
    public interface ILoot
    {
        public string Name { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int BuyPrice { get; }
        public int SellPrice { get; }
        public int MaxUses { get; }

        public virtual void Use(PlayerController player)
        {
        }

        public void Break(PlayerController player)
        {
        }

        public void AddSpentLife(PlayerController player)
        {
        }
    }
}