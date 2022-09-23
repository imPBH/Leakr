using System;
using Project_CS.Player;
using Project_CS.Loot;

namespace Project_CS.State
{
    public class ExploreState : IState
    {
        private PlayerController context;

        public ExploreState(PlayerController context)
        {
            this.context = context;
        }

        public int Battle()
        {
            Console.WriteLine("There is nothing to attack");
            return 0;
        }

        public int Explore()
        {
            Console.WriteLine("Looking around...");
            int random = new Random().Next(0, 10);

            if (random > 6)
            {
                Console.WriteLine("You found an enemy!");
                context.UpdateState(context.GetBattleState());
                return 0;
            }

            if (random > 3)
            {
                Console.WriteLine("There is nothing to see...");
                return 0;
            }

            if (random >= 0)
            {
                int randomLoot = new Random().Next(0, 16);
                if (randomLoot > 10)
                {
                    Console.WriteLine("You found a super potion!");
                    context.AddLoot(new SuperPotion());
                    return 2;
                }
                if (randomLoot > 6)
                {
                    Console.WriteLine("You found a potion!");
                    context.AddLoot(new Potion());
                    return 2;
                }

                if (randomLoot > 3)
                {
                    Console.WriteLine("You found a Discord Nitro membership!");
                    context.AddLoot(new DiscordNitro());
                    return 2;
                }

                if (randomLoot >= 0)
                {
                    Console.WriteLine("You found a deodorant!");
                    context.AddLoot(new Deodorant());
                    return 2;
                }
            }

            return 0;
        }

        public string AsciiCharacter { get; } = @"                    
      .::           
      .!?.          
    :!JY5Y!         
  .!?JJYY?5^        
  ^Y:^JYJ7Y:        
   :~7Y55J!         
     !?JJJ:         
     ~?!?J:         
     !?:??          
    .?~.J!          
    .J:.J~          
    .?^.J!          
     ~^.!!^         
";

        public int UseItem()
        {
            if (context.GetInventory().Count == 0)
            {
                Console.WriteLine("You have no items to use");
                return 0;
            }

            Console.WriteLine("Which item do you want to use?");
            context.ShowInventory();
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            foreach (var item in context.GetInventory())
            {
                if (item.Key.Name == choice)
                {
                    item.Key.Use(context);
                    return 1;
                }
            }

            Console.WriteLine("Invalid choice");
            return 0;
        }
    }
}