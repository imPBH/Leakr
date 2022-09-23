using System;
using System.Collections.Generic;
using Project_CS.Player;

namespace Project_CS.Loot
{
    public class Shop
    {
        private static List<ILoot> availableLoot = new List<ILoot>()
        {
            new Deodorant(),
            new Potion(),
            new SuperPotion(),
            new DiscordNitro(),
            new MechanicalKeyboard()
        };


        public static void Menu(PlayerController player)
        {
            Console.WriteLine("Welcome to the shop!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Leave");
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Buy(player);
                    break;
                case "2":
                    Sell(player);
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Menu(player);
                    break;
            }
        }

        private static void Buy(PlayerController player)
        {
            Console.WriteLine("What do you want to buy?");
            foreach (var loot in availableLoot)
            {
                Console.WriteLine($"{availableLoot.IndexOf(loot) + 1}. {loot.Name} - ${loot.BuyPrice}");
            }

            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            var lootIndex = int.Parse(choice) - 1;
            if (lootIndex < 0 || lootIndex >= availableLoot.Count)
            {
                Console.WriteLine("Invalid choice");
                Buy(player);
                return;
            }

            var wantedLoot = availableLoot[lootIndex];
            if (player.GetMoney() < wantedLoot.BuyPrice)
            {
                Console.WriteLine("You don't have enough money");
                Buy(player);
                return;
            }

            player.AddLoot(wantedLoot);
            player.RemoveMoney(wantedLoot.BuyPrice);
            Console.WriteLine($"You bought {wantedLoot.Name}");
        }

        private static void Sell(PlayerController player)
        {
            Console.WriteLine("What do you want to sell?");
            foreach (var playerLoot in player.GetInventory())
            {
                Console.WriteLine($"{playerLoot.Key.Name}. - ${playerLoot.Key.SellPrice}");
            }

            Console.Write("Your choice: ");
            var choice = Console.ReadLine();

            foreach (var playerLoot in player.GetInventory())
            {
                if (playerLoot.Key.Name == choice)
                {
                    Console.WriteLine($"You sold {playerLoot.Key.Name}");
                    player.AddMoney(playerLoot.Key.SellPrice);
                    player.RemoveLoot(playerLoot.Key);
                    return;
                }
            }

            Console.WriteLine("Invalid choice");
            Sell(player);
        }
    }
}