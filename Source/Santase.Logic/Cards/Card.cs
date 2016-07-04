namespace Santase.Logic.Cards
{
    using Exceptions;


    public class Card
    {

        #region Properties

        /// <summary>
        /// Боя на картата
        /// </summary>
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// Тип на картата
        /// </summary>
        public CardType Type { get; private set; }

        #endregion

        #region Constructor

        public Card(CardSuit suit, CardType type)
        {
            this.Suit = suit;
            this.Type = type;
        }

        #endregion

        #region Mehtods

        public override bool Equals(object obj)
        {
            var anotherCard = obj as Card;

            if (anotherCard == null)
            {
                return false;
            }

            return this.Suit == anotherCard.Suit && this.Type == anotherCard.Type;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Type.ToFriendlyString(), this.Suit.ToFriendlyString());
        }

        public int GetValue()
        {
            switch (this.Type)
            {
                case CardType.Nine:
                    return 0;
                case CardType.Jack:
                    return 2;
                case CardType.Queen:
                    return 3;
                case CardType.King:
                    return 4;
                case CardType.Ten:
                    return 10;
                case CardType.Ace:
                    return 11;
                default:
                    throw new InternalGameException("Invalid card type!");
            }
        }

        #endregion
    }
}
