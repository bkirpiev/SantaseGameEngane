namespace Santase.Logic.GameLogic
{
    public interface IGameHand
    {
        void Start();

        PlayerPosition Winner { get; }
    }
}
