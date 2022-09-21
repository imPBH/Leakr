using System;

namespace Project_CS
{
    public class GameController
    {
        static PlayerController player = new PlayerController();
        static int score;
        static int nextLevel = 10;

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
        }
    }
}