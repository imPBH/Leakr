using System;
using System.Collections.Generic;
using System.Linq;
using Project_CS.Entity;
using Project_CS.Game;
using Project_CS.Level;
using Project_CS.Player;
using Project_CS.Loot;

namespace Project_CS.State
{
    public class BattleState : IState
    {
        private PlayerController context;
        private int round = 1;
        private int successfullHits = 0;

        private ILevel gameLevel()
        {
            return GameLevels.GetLevel(context.GetGameLevel());
        }

        private IEntity opponent()
        {
            return gameLevel().GetOpponent();
        }

        public BattleState(PlayerController context)
        {
            this.context = context;
        }

        private void addSpentLifeToItems()
        {
            List<ILoot> items = context.GetWearingList().ToList();
            foreach (var item in items)
            {
                item.AddSpentLife(context);
            }
        }

        private void playerAttackAction()
        {
            Console.WriteLine($"You attack the {opponent().Name}");
            int ran = new Random().Next(0, 100);
            if (ran <= opponent().Defense)
            {
                Console.WriteLine($"The {opponent().Name} blocked your attack");
            }
            else
            {
                opponent().Health -= context.GetAttack();
                Console.WriteLine($"You hit the {opponent().Name}!");
                successfullHits++;
            }
        }

        private void opponentAttackAction()
        {
            Console.WriteLine($"The {opponent().Name} attack you");
            int ran = new Random().Next(0, 100);
            if (ran <= context.GetDefense())
            {
                Console.WriteLine($"You blocked the {opponent().Name} attack");
            }
            else
            {
                context.UpdateHealth(context.GetHealth() - opponent().Attack);
                Console.WriteLine($"The {opponent().Name} hit you!");
            }

            addSpentLifeToItems();
        }

        public int Battle()
        {
            if (context.GetHealth() <= 0)
            {
                Console.WriteLine("You died ! After a good nap, you heal and continue your quest");
                context.UpdateHealth(100);
                context.UpdateState(context.GetExploreState());
                round = 1;
                successfullHits = 0;
                //opponent().Reset();
                return 0;
            }

            playerAttackAction();

            if (opponent().Health <= 0)
            {
                Console.WriteLine($"You killed the {opponent().Name}");
                context.UpdateState(context.GetExploreState());
                round = 1;
                int tmp = successfullHits;
                successfullHits = 0;
                opponent().Reset();
                if (gameLevel().IsLastSubLevel())
                {
                    gameLevel().IsFinished = true;
                    Console.WriteLine($"Congratulations ! You finished the level {gameLevel().Name}!");
                    Console.WriteLine("Here is your reward :");
                    foreach (var game in gameLevel().LeakedGames())
                    {
                        context.AddLoot(game);
                        Console.WriteLine(game.Name);
                    }

                    Console.WriteLine($"You earned {20 * gameLevel().Level} credibility points");
                    context.UpdateGameLevel(context.GetGameLevel() + 1);
                }
                else
                {
                    gameLevel().NextSubLevel();
                }

                return tmp;
            }

            opponentAttackAction();

            if (context.GetHealth() <= 0)
            {
                Console.WriteLine("You died ! After a good nap, you heal and continue your quest");
                context.UpdateHealth(100);
                context.UpdateState(context.GetExploreState());
                round = 1;
                successfullHits = 0;
                //opponent().Reset();
                return 0;
            }

            Console.WriteLine(
                $"You try to kill the {opponent().Name} | ENEMY HEALTH: {opponent().Health} HP | ROUND: {round}");

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

        public int UseItem()
        {
            if (context.GetExploreState().UseItem() == 0)
            {
                return 0;
            }

            opponentAttackAction();
            Console.WriteLine(
                $"You try to kill the {opponent().Name} | ENEMY HEALTH: {opponent().Health} HP | ROUND: {round}");
            return 1;
        }
    }
}