using System;

namespace Project_CS
{
    public class BattleState : IState
    {
        private PlayerController context;

        public BattleState(PlayerController context)
        {
            this.context = context;
        }

        public int Battle()
        {
            Console.WriteLine("You try to kill the enemy");
            return 0;
        }

        public int Explore()
        {
            Console.WriteLine("You can't explore while in combat!");
            return 0;
        }
    }
}