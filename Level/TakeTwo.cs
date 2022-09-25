using System.Collections.Generic;
using Project_CS.Entity;
using Project_CS.Loot;

namespace Project_CS.Level
{
    public class TakeTwo : ILevel
    {
        public string Name { get; } = "Take Two";
        public int Level { get; } = 4;
        public int SubLevel { get; set; } = 1;
        public int MaxSubLevel { get; } = 6;
        public bool IsFinished { get; set; } = false;

        public List<IEntity> Entities { get; } = new List<IEntity>()
        {
            new CleaningAgent(),
            new GameDeveloper(),
            new CleaningAgent(),
            new GameDeveloper(),
            new Lawyer(),
            new CEO()
        };

        public IEntity GetOpponent()
        {
            return Entities[SubLevel - 1];
        }

        public int NextSubLevel()
        {
            if (SubLevel < MaxSubLevel)
            {
                SubLevel++;
                return 1;
            }

            this.IsFinished = true;
            return 0;
        }
        
        public bool IsLastSubLevel()
        {
            return SubLevel == MaxSubLevel;
        }

        public List<ILoot> LeakedGames()
        {
            List<ILoot> games = new List<ILoot>()
            {
                new NBASourceCode(),
                new RDRTwoSourceCode(),
                new GTAVISourceCode()
            };
            return games;
        }
    }
}