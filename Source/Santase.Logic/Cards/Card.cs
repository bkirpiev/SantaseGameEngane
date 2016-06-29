namespace Santase.Logic.Cards
{
    using System.Runtime.CompilerServices;


    public class Card
    {

        #region Properties

        public CardSuit Suit { get; private set; }

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

        #endregion
    }
}
