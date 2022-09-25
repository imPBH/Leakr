using System.Collections.Generic;
using Project_CS.Entity;

namespace Project_CS.Level
{
    public interface ILevel
    {
        public string Name { get;}
        public int Level { get;}
        public int SubLevel { get; set; }
        public int MaxSubLevel { get;}
        public List<IEntity> Entities { get;}
        public bool IsFinished { get; set; }

        public bool IsLastSubLevel();
        
        public IEntity GetOpponent();
        public int NextSubLevel();
    }
}