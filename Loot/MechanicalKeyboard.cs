using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class MechanicalKeyboard : ILoot
    {
        public string Name { get; } = "Mechanical Keyboard";
        public int Attack { get; } = 2;
        public int Defense { get; } = 2;
        public int BuyPrice { get; } = 6;
        public int SellPrice { get; } = 3;

        public int MaxUses { get; } = 5;
        private int lifeTime = 5;
        private int spentLife = 0;

        public void Use(PlayerController player)
        {
            if (player.WearItem(new MechanicalKeyboard()) == 0)
            {
                return;
            }

            Console.WriteLine("You used the Mechanical Keyboard");
            player.UpdateAttack(player.GetAttack() + Attack);
            player.RemoveLoot(this);
        }

        public void Break(PlayerController player)
        {
            Console.WriteLine("You broke the Mechanical Keyboard");
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