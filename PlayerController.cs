namespace Project_CS
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
    }
}