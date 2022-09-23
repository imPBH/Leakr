using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class SuperPotion : Potion
    {
        public override int BuyPrice { get; } = 10;
        public override int SellPrice { get; } = 5;
        public override string Name { get; } = "Super Potion";

        public override void Use(PlayerController player)
        {
            Console.WriteLine("You healed 20 HP!");
            player.UpdateHealth(player.GetHealth() + 20);
            this.Break(player);
        }
    }
}