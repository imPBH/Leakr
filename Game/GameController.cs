﻿using System;
using System.Threading;
using Project_CS.Loot;
using Project_CS.Player;

namespace Project_CS.Game
{
    public class GameController
    {
        static PlayerController player = new PlayerController();
        static int score;
        static int nextLevel = 10;

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
            Thread.Sleep(1000);
            PrintSlowly("But be careful, the game companies are trying to stop you!");
            Thread.Sleep(1000);
            PrintSlowly("You'll have to avoid their security and their lawyers.");
            Thread.Sleep(1000);
            PrintSlowly("While you're exploring the game companies, you'll find some items that will help you.");
            Thread.Sleep(1000);
            PrintSlowly("Each leaked game will give you credibility.");
            Thread.Sleep(1000);
            PrintSlowly("If you lose against a game company, you'll lose credibility, and you'll have to pay a fine.");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Q && player.GetLevel() < 10)
            {
                Console.WriteLine(player.GetCurrentState().AsciiCharacter);
                Console.WriteLine("______________________________________________");
                Console.WriteLine($"LVL: {player.GetLevel()} |  HP: {player.GetHealth()} | DEF: {player.GetDefense()} | CRED: 0 | $: {player.GetMoney()}" );
                Console.WriteLine();
                Console.WriteLine("L = Look Around, A = Attack, I = Inventory, U = Use Item, S = Shop Q = Quit");
                //Console.Write("Score [" + score + "] Level [" + player.GetLevel() + "] Action [L,A,I,S,U,Q]: ");

                key = Console.ReadKey();
                Console.Clear();
                ExecuteChoice(key.Key);
            }

            if (player.GetLevel() == 10)
            {
                Console.WriteLine();
                Console.WriteLine("You win! Your score is " + score);
            }
        }

        private static void ExecuteChoice(ConsoleKey key)
        {
            if (key == ConsoleKey.L)
            {
                int points = player.Explore();
                if (points > 0)
                {
                    Console.WriteLine("You gained " + points + " points!");
                    score += points;
                }
            }
            else if (key == ConsoleKey.A)
            {
                int points = player.Battle();
                if (points > 0)
                {
                    score += points;
                    Console.WriteLine("You gained " + points + " points!");
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
            }

            if (score >= nextLevel)
            {
                player.UpdateLevel(player.GetLevel() + 1);
                nextLevel += player.GetLevel() * 10;

                Console.WriteLine("You leveled up! You are now level " + player.GetLevel());
            }
        }

        static void PrintSlowly(string print)
        {
            foreach (char l in print)
            {
                Console.Write(l);
                Thread.Sleep(10); // sleep for 10 milliseconds    
            }

            Console.Write("\n");
        }
    }
}