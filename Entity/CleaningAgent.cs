namespace Project_CS.Entity
{
    public class CleaningAgent : IEntity
    {
        public string Name { get; set; } = "Cleaning Agent";
        public int Health { get; set; } = 65;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
        
        public void Reset()
        {
            Health = 65;
        }
    }
}