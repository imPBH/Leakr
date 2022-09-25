using System;
using System.Collections.Generic;
using Project_CS.Level;

namespace Project_CS.Game
{
    public class GameLevels
    {
        public static List<ILevel> levels = new List<ILevel>()
        {
            new EpicGames(),
            new Activision(),
            new Ubisoft(),
            new TakeTwo()
        };

        public static ILevel GetLevel(int level)
        {
            return levels[level];
        }

        public static ILevel GetLastLevel()
        {
            return levels[levels.Count - 1];
        }
    }
}