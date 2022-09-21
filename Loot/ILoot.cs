using Project_CS.Player;

namespace Project_CS.Loot
{
    public interface ILoot
    {
        public string Name { get;} 
        public int Attack { get;}
        public int Defense { get;}
        public virtual void Use(PlayerController player)
        {
        }

        public void Break(PlayerController player)
        {
        }
    }
}