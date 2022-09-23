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

        public int MaxUses { get; } = 1;
        private int lifeTime = 3;
        private int spentLife = 0;
        public void Use(PlayerController player)
        {
            if (player.WearItem(this) == 0)
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