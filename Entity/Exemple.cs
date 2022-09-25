namespace Project_CS.Entity
{
    public class Exemple : IEntity
    {
        public string Name { get; set; } = "Exemple de nom";
        public int Health { get; set; } = 100;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
    }
}