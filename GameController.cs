using System;

namespace Project_CS
{
    public class GameController
    {
        static PlayerController player = new PlayerController();
        static int score;
        static int nextLevel = 10;

        public void Start()
        {
            Console.WriteLine("Welcome to the game!");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Q && player.GetLevel() < 10)
            {
                Console.WriteLine("L = Look Around, A = Attack, Q = Quit");
                Console.Write("Score [" + score + "] Level [" + player.GetLevel() + "] Action [L,A,Q]: ");
                

                key = Console.ReadKey();
                Console.Clear();
                ExecuteChoice(key.Key);
                
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
                int rounds = player.Battle();
                if (rounds > 0)
                {
                    int points = 10 - rounds;
                    if (points < 0)
                    {
                        points = 0;
                    }

                    score += points;
                    Console.WriteLine("You gained " + points + " points!");
                }
            }

            if (score >= nextLevel)
            {
                player.UpdateLevel(player.GetLevel() + 1);
                nextLevel += player.GetLevel() * 10;

                Console.WriteLine("You leveled up! You are now level " + player.GetLevel());
            }
        }
    }
}