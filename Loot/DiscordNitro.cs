using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class DiscordNitro : ILoot
    {
        public string Name { get; } = "Discord Nitro";
        public int Attack { get; } = 2;
        public int Defense { get; } = 1;
        public int BuyPrice { get; } = 5;
        public int SellPrice { get; } = 3;

        public int MaxUses { get; } = 5;
        private int lifeTime = 6;
        private int spentLife = 0;

        public void Use(PlayerController player)
        {
            if (player.WearItem(new DiscordNitro()) == 0)
            {
                return;
            }

            Console.WriteLine("You used Discord Nitro!");
            player.UpdateAttack(player.GetAttack() + Attack);
            player.RemoveLoot(this);
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("Your Discord Nitro membership has expired!");
            player.UpdateAttack(player.GetAttack() - Attack);
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