namespace Santase.Logic.GameLogic
{
    using Cards;


    public interface IGameHand
    {
        void Start();

        PlayerPosition Winner { get; }

        Card FirstPlayerCard { get; }

        Announce FirstPlayerAnnounce { get; }

        Card SecondPlayerCard { get; }

        Announce SecondPlayerAnnounce { get; }
    }
}
