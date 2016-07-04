namespace Santase.Logic.GameLogic
{
    using Cards;


    public class GameHand : IGameHand
    {

        public GameHand()
        {

        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public PlayerPosition Winner
        {
            get { throw new System.NotImplementedException(); }
        }

        public Card FirstPlayerCard
        {
            get { throw new System.NotImplementedException(); }
        }

        public Announce FirstPlayerAnnounce
        {
            get { throw new System.NotImplementedException(); }
        }

        public Card SecondPlayerCard
        {
            get { throw new System.NotImplementedException(); }
        }

        public Announce SecondPlayerAnnounce
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
