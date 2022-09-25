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
            Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Invalid choice");
                    Menu(player);
                    break;
            }
        }

        private static void Buy(PlayerController player)
        {
            Console.WriteLine("What do you want to buy?");
            Console.WriteLine();
            foreach (var loot in availableLoot)
            {
                Console.WriteLine($"{availableLoot.IndexOf(loot) + 1}. {loot.Name} - ${loot.BuyPrice}");
            }

            Console.WriteLine();
            Console.WriteLine("0. Back to home");
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            int choiceInt;
            bool isParsable = Int32.TryParse(choice, out choiceInt);
            if (!isParsable)
            {
                Console.Clear();
                Console.WriteLine("Invalid choice");
                Buy(player);
                return;
            }

            if (choice == "0")
            {
                return;
            }

            var lootIndex = int.Parse(choice) - 1;
            if (lootIndex < 0 || lootIndex >= availableLoot.Count)
            {
                Console.Clear();
                Console.WriteLine("Invalid choice");
                Buy(player);
                return;
            }

            var wantedLoot = availableLoot[lootIndex];
            if (player.GetMoney() < wantedLoot.BuyPrice)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough money");
                Buy(player);
                return;
            }

            player.AddLoot(wantedLoot);
            player.RemoveMoney(wantedLoot.BuyPrice);
            Console.WriteLine($"You bought {wantedLoot.Name}");
        }

        public static void Sell(PlayerController player)
        {
            if (player.GetInventory().Count == 0)
            {
                Console.WriteLine("You don't have any loot to sell");
                return;
            }

            Console.WriteLine("What do you want to sell?");
            Console.WriteLine();
            foreach (var playerLoot in player.GetInventory())
            {
                Console.WriteLine($"{playerLoot.Key.Name}. - ${playerLoot.Key.SellPrice}");
            }

            Console.WriteLine();
            Console.WriteLine("0. Back to home");
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            if (choice == "0")
            {
                return;
            }

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

            Console.Clear();
            Console.WriteLine("Invalid choice");
            Sell(player);
        }
    }
}