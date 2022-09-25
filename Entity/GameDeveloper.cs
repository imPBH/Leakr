namespace Project_CS.Entity
{
    public class esport_player : IEntity
    {
        public string Name { get; set; } = "e-sport player";
        public int Health { get; set; } = 80;
        public int Attack { get; set; } = 20;
        public int Defense { get; set; } = 10;
    }
}