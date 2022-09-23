using System;
using Project_CS.Player;

namespace Project_CS.State
{
    public class BattleState : IState
    {
        private PlayerController context;
        private int round = 1;

        public BattleState(PlayerController context)
        {
            this.context = context;
        }

        public int Battle()
        {
            Console.WriteLine("You try to kill the enemy | ROUND " + round);
            int maxRandom = 10 - context.GetLevel();
            if (maxRandom < 1)
            {
                maxRandom = 1;
            }

            int ran = new Random().Next(0, maxRandom);

            if (ran == 0)
            {
                Console.WriteLine("You killed the enemy");
                int tmp = round;
                round = 1;
                context.UpdateState(context.GetExploreState());
                return tmp;
            }

            Console.WriteLine("You failed to kill the enemy");
            round++;


            if (round > 9)
            {
                Console.WriteLine("You lost the battle");
                round = 1;
                context.UpdateState(context.GetExploreState());
            }

            return 0;
        }

        public int Explore()
        {
            Console.WriteLine("You can't explore while you're in a battle!");
            return 0;
        }

        public string AsciiCharacter { get; } = @"                                        
                                        
                              ..        
                      .       7Y?:      
                     .!~!?J7!7?5P5?7:   
                          ...7Y?J5JJ!   
        ..                    ~J?JYY.   
      :?Y?       .           .~7???!    
   :7?5P5?777J?!~!.         ^7~::~!:    
   !JJ5J?Y7...             :7^.  ^7:    
   .YYJ?J~                 ::    .~^.   
    !???7~.               .~^     .::   
    :!~::~7^              ^^.      !!   
    :7^  .^7:                           
   .^~.    ::                           
   ::.     ^~.                          
   7!      .^^                          
                                        
";
    }
}