using System;
using Project_CS.Player;

namespace Project_CS.State
{
    public class BattleState : IState
    {
        private PlayerController context;
        private int round = 1;
        private int successfullHits = 0;
        private int opponentHealth = 100;
        private int opponentAttack = 20;
        private int opponentDefense = 20;

        public BattleState(PlayerController context)
        {
            this.context = context;
        }

        public int Battle()
        {
            Console.WriteLine("You attack the enemy");
            int ran = new Random().Next(0, 100);
            if (ran <= opponentDefense)
            {
                Console.WriteLine("The enemy blocked your attack");
            }
            else
            {
                opponentHealth -= context.GetAttack();
                Console.WriteLine("You hit the enemy!");
                successfullHits++;
            }

            if (opponentHealth <= 0)
            {
                Console.WriteLine("You killed the enemy");
                context.UpdateState(context.GetExploreState());
                round = 1;
                int tmp = successfullHits;
                successfullHits = 0;
                opponentHealth = 100;
                return tmp;
            }

            Console.WriteLine("The enemy attack you");
            ran = new Random().Next(0, 100);
            if (ran <= context.GetDefense())
            {
                Console.WriteLine("You blocked the enemy attack");
            }
            else
            {
                context.UpdateHealth(context.GetHealth() - opponentAttack);
                Console.WriteLine("The enemy hit you!");
            }

            if (context.GetHealth() <= 0)
            {
                Console.WriteLine("You died");
                context.UpdateState(context.GetExploreState());
                round = 1;
                successfullHits = 0;
                opponentHealth = 100;
                return 0;
            }

            Console.WriteLine("You try to kill the enemy | ENEMY HEALTh: " + opponentHealth + "HP | ROUND " + round);

            round++;
            return -1;
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