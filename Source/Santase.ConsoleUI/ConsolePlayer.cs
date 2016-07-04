namespace Santase.ConsoleUI
{
    using System;
    using System.CodeDom;
    using System.Threading;

    using Logic.Cards;
    using Logic.Exceptions;
    using Logic.Players;


    public class ConsolePlayer : BasePlayer
    {
        private int row;
        private int col;

        /// <summary>
        /// Ще се определи къде ще се рисуват картите на всеки играч на екрана.
        /// За това са row и col
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public ConsolePlayer(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);

            // Задаваме позицията от която да се почне изрисуването на картите
            Console.SetCursorPosition(this.col, this.row);

            // Всяка от 6-те карти на играча се изрисува на екрана
            foreach (var item in this.cards)
            {
                Console.Write("{0} ", item.ToString());
            }

            Thread.Sleep(150);
        }

        public override PlayerAction GetTurn(PlayerTurnContext context)
        {
            // TODO
            Console.ReadLine();
            return new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Ace), Announce.None);
        }
    }
}
