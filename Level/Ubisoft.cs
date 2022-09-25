using System.Collections.Generic;
using Project_CS.Entity;

namespace Project_CS.Level
{
    public class Ubisoft : ILevel
    {
        public string Name { get; } = "Ubisoft";
        public int Level { get; } = 3;
        public int SubLevel { get; } = 1;
        public int MaxSubLevel { get; } = 5;
        public List<IEntity> Entities { get; } = new List<IEntity>()
        {
            new CleaningAgent(),
            new GameDeveloper(),
            new CleaningAgent(),
            new Lawyer(),
            new CEO()
        };
    }
}