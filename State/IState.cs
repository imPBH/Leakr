namespace Project_CS.State
{
    public interface IState
    {
        int Explore();
        int Battle();
        string AsciiCharacter { get; }
    }
}