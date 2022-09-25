namespace Project_CS.Entity
{
    public class Lawyer : IEntity
    {
        public string Name { get; set; } = "Lawyer";
        public int Health { get; set; } = 90;
        public int Attack { get; set; } = 25;
        public int Defense { get; set; } = 25;
        
        public void Reset()
        {
            Health = 90;
        }
    }
}