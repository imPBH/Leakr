using System;
using System.Threading;
using Project_CS.Level;
using Project_CS.Loot;
using Project_CS.Player;

namespace Project_CS.Game
{
    public class GameController
    {
        static PlayerController player = new PlayerController();
        static int nextLevel = 10;
        private ILevel gameLevel = GameLevels.GetLevel(player.GetGameLevel());
        public void Start()
        {
            var arr = new[]
            {
                @" ▄█          ▄████████    ▄████████    ▄█   ▄█▄    ▄████████ ",
                @"███         ███    ███   ███    ███   ███ ▄███▀   ███    ███ ",
                @"███         ███    █▀    ███    ███   ███▐██▀     ███    ███ ",
                @"███        ▄███▄▄▄       ███    ███  ▄█████▀     ▄███▄▄▄▄██▀ ",
                @"███       ▀▀███▀▀▀     ▀███████████ ▀▀█████▄    ▀▀███▀▀▀▀▀   ",
                @"███         ███    █▄    ███    ███   ███▐██▄   ▀███████████ ",
                @"███▌    ▄   ███    ███   ███    ███   ███ ▀███▄   ███    ███ ",
                @"█████▄▄██   ██████████   ███    █▀    ███   ▀█▀   ███    ███ ",
                @"▀                                     ▀           ███    ███ "
            };
            foreach (string line in arr)
                Console.WriteLine(line);
            PrintSlowly("Welcome to the game!");
            PrintSlowly("You are a leaker, your goal is to infiltrate game companies and leak their games.");
            Thread.Sleep(500);
            PrintSlowly("But be careful, the game companies are trying to stop you!");
            Thread.Sleep(500);
            PrintSlowly("You'll have to avoid their security and their lawyers.");
            Thread.Sleep(500);
            PrintSlowly("While you're exploring the game companies, you'll find some items that will help you.");
            Thread.Sleep(500);
            PrintSlowly("Each leaked game will give you credibility.");
            Thread.Sleep(500);
            PrintSlowly("If you lose against a game company, you'll lose credibility, and you'll have to pay a fine.");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (!GameLevels.GetLastLevel().IsFinished)
            {
                Console.WriteLine(player.GetCurrentState().AsciiCharacter);
                Console.WriteLine("____________________________________________________________________________________________");
                Console.WriteLine($"GAME LVL: {GameLevels.GetLevel(player.GetGameLevel()).Name} | PLAYER LVL: {player.GetPlayerLevel()} |  HP: {player.GetHealth()} | ATK: {player.GetAttack()} | DEF: {player.GetDefense()} | CRED: {player.GetCredibility()} | $: {player.GetMoney()}" );
                Console.WriteLine();
                Console.WriteLine("L = Look Around, A = Attack, I = Inventory, U = Use Item, S = Shop, W = Wearing List, Q = Quit");
                //Console.Write("Score [" + score + "] Level [" + player.GetLevel() + "] Action [L,A,I,S,U,W,Q]: ");

                key = Console.ReadKey();
                Console.Clear();
                ExecuteChoice(key.Key);
            }

            if (GameLevels.GetLastLevel().IsFinished)
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations ! You have leaked all the games !");
                Console.WriteLine("You finished the game with " + player.GetCredibility() + " credibility, " + player.GetMoney() + " dollars and " + player.GetPlayerLevel() + " player level.");
            }
        }

        private static void ExecuteChoice(ConsoleKey key)
        {
            if (key == ConsoleKey.L)
            {
                int points = player.Explore();
                player.UpdateCredibility(player.GetCredibility() + points);
                if (points > 0)
                {
                    Console.WriteLine("You gained " + points + " credibility!");
                }
            }
            else if (key == ConsoleKey.A)
            {
                int points = player.Battle();
                if (points > 0)
                {
                    player.UpdateCredibility(player.GetCredibility() + points);
                    Console.WriteLine("You gained " + points + " credibility!");
                }
            }
            else if (key == ConsoleKey.I)
            {
                player.ShowInventory();
            }
            else if (key == ConsoleKey.S)
            {
                Shop.Menu(player);
            } else if (key == ConsoleKey.U)
            {
                player.UseItem();
            } else if (key == ConsoleKey.W)
            {
                Console.WriteLine("Wearing List:");
                foreach (var item in player.GetWearingList())
                {
                    Console.WriteLine(item.Name);
                }
            } else if (key == ConsoleKey.Q)
            {
                System.Environment.Exit(0);
            }

            if (player.GetCredibility() >= nextLevel)
            {
                player.UpdatePlayerLevel(player.GetPlayerLevel() + 1);
                nextLevel += player.GetPlayerLevel() * 10;

                Console.WriteLine("You leveled up! You are now level " + player.GetPlayerLevel());
            }
        }

        static void PrintSlowly(string print)
        {
            foreach (char l in print)
            {
                Console.Write(l);
                Thread.Sleep(5); // sleep for 10 milliseconds    
            }

            Console.Write("\n");
        }
    }
}