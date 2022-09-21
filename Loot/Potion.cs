using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class Potion : ILoot
    {
        public virtual string Name { get; } = "Potion";
        public int Attack { get; } = 0;
        public int Defense { get; } = 0;
        public virtual void Use(PlayerController player)
        {
            player.UpdateHealth(player.GetHealth() + 10);
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("Potion broke");
            player.RemoveLoot(this);
        }
    }
}