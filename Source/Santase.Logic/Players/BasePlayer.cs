namespace Santase.Logic.Players
{
    using System.Collections.Generic;

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
        /// <returns></returns>
        public abstract PlayerAction GetTurn(PlayerTurnContext context);
    }
}
