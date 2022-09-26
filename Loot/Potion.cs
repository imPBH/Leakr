using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class Potion : ILoot
    {
        public virtual string Name { get; } = "Potion";
        public int Attack { get; } = 0;
        public int Defense { get; } = 0;
        public virtual int BuyPrice { get; } = 4;
        public virtual int SellPrice { get; } = 2;
        public int MaxUses { get; } = 999;
        public virtual void Use(PlayerController player)
        {
            Console.WriteLine("You healed 15 HP!");
            player.UpdateHealth(player.GetHealth() + 15);
            this.Break(player);
        }

        public void Break(PlayerController player)
        {
            player.RemoveLoot(this);
        }
    }
}