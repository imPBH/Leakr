using Project_CS.Player;
using System;

namespace Project_CS.Loot
{
    public class Deodorant : ILoot
    {
        public string Name { get; } = "Deodorant";
        public int Attack { get; } = 0;
        public int Defense { get; } = 2;
        public int BuyPrice { get; } = 10;
        public int SellPrice { get; } = 5;
        
        public int MaxUses { get; } = 1;
        private int lifeTime = 1;
        private int spentLife = 0;

        public void Use(PlayerController player)
        {
            if (player.WearItem(this) == 0)
            {
                return;
            }
            Console.WriteLine("You smell better now.");
            player.UpdateDefense(player.GetDefense() + Defense);
            player.RemoveLoot(this);
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("No more deodorant.");
            player.UpdateDefense(player.GetDefense() - Defense);
            player.RemoveWearingItem(this);
        }
        
        public void AddSpentLife(PlayerController player)
        {
            spentLife++;
            if (spentLife >= lifeTime)
            {
                this.Break(player);
            }
        }
    }
}