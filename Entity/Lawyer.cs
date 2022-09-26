namespace Project_CS.Entity
{
    public class Lawyer : IEntity
    {
        public string Name { get; set; } = "Lawyer";
        public int Health { get; set; } = 85;
        public int Attack { get; set; } = 15;
        public int Defense { get; set; } = 35;

        public void Reset()
        {
            Health = 85;
        }
    }
}