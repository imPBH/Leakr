namespace Project_CS.Entity
{
    public class CEO : IEntity
    {
        public string Name { get; set; } = "Company CEO";
        public int Health { get; set; } = 150;
        public int Attack { get; set; } =25 ;
        public int Defense { get; set; } = 30;
        
        public void Reset()
        {
            Health = 150;
        }
    }
}
