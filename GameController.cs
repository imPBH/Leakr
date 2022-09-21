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
        }
    }
}