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

        public void Use(PlayerController player)
        {
            Console.WriteLine("You smell better now.");
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("No more deodorant.");
            player.RemoveLoot(this);
        }
        
    }
}