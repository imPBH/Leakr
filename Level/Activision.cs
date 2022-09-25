using System.Collections.Generic;
using Project_CS.Entity;

namespace Project_CS.Level
{
    public class Activision : ILevel
    {
        public string Name { get;} = "Activision";
        public int Level { get; } = 2;
        public int SubLevel { get; } = 1;
        public int MaxSubLevel { get; } = 4;
        public List<IEntity> Entities { get; } = new List<IEntity>()
        {
            new CleaningAgent(),
            new GameDeveloper(),
            new Lawyer(),
            new CEO()
        };
    }
}