namespace Santase.Logic.Cards
{
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    using Extensions;

    public class Deck : IDeck
    {
        #region Fields

        private IList<Card> listOfCards;

        private Card trumCard;

        #endregion


        #region Constructors

        public Deck()
        {
            listOfCards = new List<Card>();

            // Попълване на тестесто с карти
            foreach (var cardSuit in GetAllCardSuit())
            {
                foreach (var cardType in GetAllCardType())
                {
                    listOfCards.Add(new Card(cardSuit, cardType));
                }
            }

            // Размешване на картите
            this.listOfCards = listOfCards.Shuffle().ToList();

            // задавам коя да е козовата карта
            trumCard = listOfCards[0];
        }

        #endregion


        #region Methods

        /// <summary>
        /// Взима последната карта от списъка.
        /// </summary>
        /// <returns></returns>
        public Card GetNextCard()
        {
            if (listOfCards.Count == 0)
            {
                throw new InternalGameException("Deck is empty!");
            }

            var card = listOfCards[listOfCards.Count - 1];
            listOfCards.RemoveAt(listOfCards.Count - 1);

            return card;
        }

        public Card GetTrumpCard
        {
            get
            {
                return this.trumCard;
            }
        }

        public void ChangeTrumpCard(Card newCard)
        {
            this.trumCard = newCard;

            if (listOfCards.Count > 0)
            {
                listOfCards[0] = newCard;
            }
        }

        private IEnumerable<CardType> GetAllCardType()
        {
            return new List<CardType>
            {
                CardType.Nine,
                CardType.Ten,
                CardType.Jack,
                CardType.Queen,
                CardType.King,
                CardType.Ace
            };
        }

        private IEnumerable<CardSuit> GetAllCardSuit()
        {
            return new List<CardSuit>
            {
                CardSuit.Club,
                CardSuit.Diamond,
                CardSuit.Heart,
                CardSuit.Spade,
            };
        }

        #endregion
   
    }
}
