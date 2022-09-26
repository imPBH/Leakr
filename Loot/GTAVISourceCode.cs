using System;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class GTAVISourceCode : ILoot
    {
        public string Name { get;} = "GTA 6 Source Code";
        public int Attack { get;} = 0;
        public int Defense { get;} = 0;
        public int BuyPrice { get;} = 0;
        public int SellPrice { get;} = 70;
        public int MaxUses { get;} = 1;

        public void Use(PlayerController player)
        {
            Console.WriteLine("You can't use this item");
        }
        
        public void Break(PlayerController player)
        {
        }
    }
}