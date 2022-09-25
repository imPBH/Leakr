namespace Project_CS.Entity
{
    public class GameDeveloper : IEntity
    {
        public string Name { get; set; } = "Game Developer";
        public int Health { get; set; } = 75;
        public int Attack { get; set; } = 15;
        public int Defense { get; set; } = 10;
        
        public void Reset()
        {
            Health = 75;
        }
    }
}