using Project_CS.Loot;

namespace Project_CS.State
{
    public interface IState
    {
        int Explore();
        int Battle();
        string AsciiCharacter { get; }
        public int UseItem();
    }
}