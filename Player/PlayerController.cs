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
        private IState battleState;
        private int level;
        private int exp;
        private int health = 100;
        private int attack = 20;
        private int defense = 20;
        private int stockInventory;
        private int inventoryLimit = 15;
        private string name = "";
        private int money;
        private Dictionary<ILoot, int> inventory = new Dictionary<ILoot, int>();
        private List<ILoot> wearingList = new List<ILoot>();

        public PlayerController()
        {
            exploreState = new ExploreState(this);
            battleState = new BattleState(this);
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
        
        public void UpdateAttack(int newAttack)
        {
            attack = newAttack;
        }
        
        public void UpdateDefense(int newDefense)
        {
            defense = newDefense;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetMoney()
        {
            return money;
        }

        public void RemoveMoney(int amount)
        {
            money -= amount;
        }

        public void AddMoney(int amount)
        {
            money += amount;
        }

        public Dictionary<ILoot, int> GetInventory()
        {
            return inventory;
        }

        public int GetExp()
        {
            return exp;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
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
            return battleState;
        }

        public IState GetCurrentState()
        {
            return currentState;
        }

        public void AddLoot(ILoot loot)
        {
            if (stockInventory == inventoryLimit)
            {
                Console.WriteLine("Your inventory is full");
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("1. Delete an item");
                Console.WriteLine("2. Don't take this item");
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Shop.Sell(this);
                        return;

                    case ConsoleKey.D2:
                        return;

                    default:
                        Console.WriteLine("Invalid Input");
                        return;
                }
            }

            if (inventory.Count == 0)
            {
                inventory.Add(loot, 1);
                stockInventory++;
            }
            else
            {
                foreach (KeyValuePair<ILoot, int> item in inventory)
                {
                    if (item.Key.Name == loot.Name)
                    {
                        inventory[item.Key] += 1;
                        stockInventory++;
                        return;
                    }
                }

                inventory.Add(loot, 1);
                stockInventory++;
            }
        }

        public void RemoveLoot(ILoot loot)
        {
            foreach (KeyValuePair<ILoot, int> item in inventory)
            {
                if (item.Key.Name == loot.Name)
                {
                    inventory[item.Key] -= 1;
                    stockInventory--;
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

        public void UseItem()
        {
            currentState.UseItem();
        }
        
        public int WearItem(ILoot item)
        {
            int nbOfItem = 0;
            foreach (var wearedItem in wearingList)
            {
                if (wearedItem.Name == item.Name)
                {
                    nbOfItem++;
                }
            }
            if (nbOfItem >= item.MaxUses)
            {
                Console.WriteLine("You can't wear more than " + item.MaxUses + " " + item.Name);
                return 0;
            }
            wearingList.Add(item);
            return 1;
        }
        
        public void RemoveWearingItem(ILoot item)
        {
            wearingList.Remove(item);
        }
        
        public List<ILoot> GetWearingList()
        {
            return wearingList;
        }
    }
}