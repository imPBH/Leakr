using System;
using System.Collections.Generic;
using Project_CS.State;
using Project_CS.Loot;

namespace Project_CS.Player
{
    public class PlayerController
    {
        private IState currentState;
        private IState exploreState;
        private IState batttleState;
        private int level;
        private int exp;
        private int health;
        private string name = "";
        Dictionary<ILoot, int> inventory = new Dictionary<ILoot, int>();

        public PlayerController()
        {
            exploreState = new ExploreState(this);
            batttleState = new BattleState(this);
            currentState = exploreState;
        }

        public int Explore()
        {
            return currentState.Explore();
        }

        public int Battle()
        {
            return currentState.Battle();
        }

        public void UpdateState(IState newState)
        {
            currentState = newState;
        }

        public void UpdateLevel(int newLevel)
        {
            level = newLevel;
        }

        public void UpdateExp(int newExp)
        {
            exp = newExp;
        }

        public void UpdateHealth(int newHealth)
        {
            health = newHealth;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetExp()
        {
            return exp;
        }

        public int GetHealth()
        {
            return health;
        }

        public string GetName()
        {
            return name;
        }

        public IState GetExploreState()
        {
            return exploreState;
        }

        public IState GetBattleState()
        {
            return batttleState;
        }
        
        public IState GetCurrentState()
        {
            return currentState;
        }

        public void AddLoot(ILoot loot)
        {
            if (inventory.Count == 0)
            {
                inventory.Add(loot, 1);
            }
            else
            {
                foreach (KeyValuePair<ILoot, int> item in inventory)
                {
                    if (item.Key.Name == loot.Name)
                    {
                        inventory[item.Key] += 1;
                        return;
                    }
                }

                inventory.Add(loot, 1);
            }
        }

        public void RemoveLoot(ILoot loot)
        {
            foreach (KeyValuePair<ILoot, int> item in inventory)
            {
                if (item.Key.Name == loot.Name)
                {
                    inventory[item.Key] -= 1;
                    if (inventory[item.Key] == 0)
                    {
                        inventory.Remove(item.Key);
                    }

                    return;
                }
            }
        }

        public void ShowInventory()
        {
            foreach (KeyValuePair<ILoot, int> loot in inventory)
            {
                Console.WriteLine(loot.Key.Name + " x" + loot.Value);
            }
        }
    }
}