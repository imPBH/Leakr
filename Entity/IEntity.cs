namespace Project_CS.Entity
{
    public interface IEntity
    {
        public string Name { get; } 
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        
        public void Reset();
    }
}