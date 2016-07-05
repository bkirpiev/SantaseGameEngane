namespace Santase.Logic.Players
{
    using Cards;

    using RoundStates;


    public class PlayerTurnContext
    {
        public Card TrumpCard { get; private set; }

        public int CardsLeft { get; private set; }

        public PlayerTurnContext(Card trumpCard, BaseRoundState state, int cardsLeftInDeck)
        {
            this.TrumpCard = trumpCard;
            this.State = state;
            this.CardsLeft = cardsLeftInDeck;
        }

        /// <summary>
        /// Коя е първата изиграна карта
        /// </summary>
        public Card FirstPlayedCard { get; internal set; }

        /// <summary>
        /// Коя е втората изиграна карта
        /// </summary>
        public Card SecondPlayedCard { get; internal set; }

        public bool AmITheFirstPlayer
        {
            get
            {
                return this.FirstPlayedCard == null;
            }
        }

        public BaseRoundState State { get; private set; }
    }
}
