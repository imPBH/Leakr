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
    }
}