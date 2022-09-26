using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class SuperPotion : Potion
    {
        public override int BuyPrice { get; } = 6;
        public override int SellPrice { get; } = 3;
        public override string Name { get; } = "Super Potion";

        public override void Use(PlayerController player)
        {
            Console.WriteLine("You healed 25 HP!");
            player.UpdateHealth(player.GetHealth() + 25);
            this.Break(player);
        }
    }
}