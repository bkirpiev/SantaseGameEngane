namespace Santase.Logic.Players
{
    using System.Collections.Generic;
    using System.Runtime.Serialization.Formatters;

    using Cards;


    public abstract class BasePlayer : IPlayer
    {
        protected IList<Card> cards;

        protected BasePlayer()
        {
            this.cards = new List<Card>();
        }

        /// <summary>
        /// Наследниците могат да сменят поведениято на метода
        /// </summary>
        /// <param name="card"></param>
        public virtual void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        /// <summary>
        /// Идеята, е че всеки играч дали изкуствен интелект или мрежови, ще ползва и пренапише този метод
        /// </summary>
        /// <param name="context"></param>
        /// <param name="actionValidater"></param>
        /// <returns></returns>
        public abstract PlayerAction GetTurn(PlayerTurnContext context, IPlayerActionValidater actionValidater);

        protected Announce PossibeAnnounce(Card cardToBePlayed, Card trumpCard)
        {
            CardType cartTypeToSearch = CardType.Ace;

            if (cardToBePlayed.Type == CardType.Queen)
            {
                cartTypeToSearch = CardType.King;
            }
            else if (cardToBePlayed.Type == CardType.King)
            {
                cartTypeToSearch = CardType.Queen;
            }

            if (cardToBePlayed.Type != CardType.Queen && cardToBePlayed.Type != CardType.King)
            {
                return  Announce.None;
            }

            var cardToSearch = new Card(cardToBePlayed.Suit, cartTypeToSearch);

            if (!this.cards.Contains(cardToSearch))
            {
                return Announce.None;
            }

            if (cardToBePlayed.Suit == trumpCard.Suit)
            {
                return Announce.Fourty;
            }
            else
            {
                return Announce.Twenty;
            }

        }
    }
}
