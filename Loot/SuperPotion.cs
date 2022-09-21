using Project_CS.Player;

namespace Project_CS.Loot
{
    public class SuperPotion : Potion
    {
        public override string Name { get; } = "Super Potion";
        public override void Use(PlayerController player)
        {
            player.UpdateHealth(player.GetHealth() + 20);
        }
    }
}