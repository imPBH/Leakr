using System.Collections.Generic;
using Project_CS.Entity;

namespace Project_CS.Level
{
    public class TakeTwo : ILevel
    {
        public string Name { get; } = "Take Two";
        public int Level { get; } = 4;
        public int SubLevel { get; } = 1;
        public int MaxSubLevel { get; } = 6;

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