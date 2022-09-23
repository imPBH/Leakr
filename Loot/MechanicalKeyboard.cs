using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class MechanicalKeyboard : ILoot
    {
        public string Name { get; } = "Mechanical Keyboard";
        public int Attack { get; } = 1;
        public int Defense { get; } = 0;
        public int BuyPrice { get; } = 8;
        public int SellPrice { get; } = 4;

        public void Use(PlayerController player)
        {
            Console.WriteLine("You use the Mechanical Keyboard");
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("You broke the Mechanical Keyboard");
            player.RemoveLoot(this);
        }
    }
}