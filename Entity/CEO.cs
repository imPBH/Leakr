namespace Project_CS.Entity
{
    public class CEO : IEntity
    {
        public string Name { get; set; } = "Company CEO";
        public int Health { get; set; } = 100;
        public int Attack { get; set; } = 20 ;
        public int Defense { get; set; } = 25;
        
        public void Reset()
        {
            Health = 100;
        }
    }
}
