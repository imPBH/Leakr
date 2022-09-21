using System;

namespace Project_CS
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
                Console.WriteLine("You found a treasure!");
                return 2;
            }

            return 0;
        }
    }
}