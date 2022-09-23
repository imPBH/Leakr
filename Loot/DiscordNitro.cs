using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class DiscordNitro : ILoot
    {
        public string Name { get; } = "Discord Nitro";
        public int Attack { get; } = 2;
        public int Defense { get; } = 0;
        public int BuyPrice { get; } = 10;
        public int SellPrice { get; } = 5;

        public void Use(PlayerController player)
        {
            Console.WriteLine("You used Discord Nitro!");
        }
        
        public void Break(PlayerController player)
        {
            Console.WriteLine("Your Discord Nitro membership has expired!");
            player.RemoveLoot(this);
        }
    }
}