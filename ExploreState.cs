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
            return 0;
        }
    }
}