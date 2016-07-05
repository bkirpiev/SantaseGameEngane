namespace Santase.ConsoleUI
{
    using System;
    using System.CodeDom;
    using System.Diagnostics;
    using System.Net;
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

        /// <summary>
        /// Пита юзера какво ще прави
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override PlayerAction GetTurn(PlayerTurnContext context, IPlayerActionValidater actionValidater)
        {
            PrintGameInfo(context);

            while (true)
            {
                PlayerAction playerAction = null;

                Console.SetCursorPosition(0, this.row - 2);
                Console.Write("Turn? [1-{0}]=Card{1} ",this.cards.Count, context.AmITheFirstPlayer ? "; [T]=Change trump; [C]=Close:" : ":");

                var userActionAsString = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userActionAsString))
                {
                    Console.WriteLine("Invalid Turn    ");
                    continue;
                }

                if (userActionAsString[0] >= '1' && userActionAsString[0] <= '6')
                {
                    var cardIndex = int.Parse(userActionAsString[0].ToString());

                    if (cardIndex >= this.cards.Count)
                    {
                        Console.WriteLine("Invalid card!   ");
                        continue;
                    }

                    var card = this.cards[cardIndex];

                    var possibleAnnounce = Announce.None;

                    if (context.AmITheFirstPlayer)
                    {
                        possibleAnnounce = this.PossibeAnnounce(card, context.TrumpCard);

                        if (possibleAnnounce != Announce.None)
                        {

                            while (true)
                            {
                                Console.SetCursorPosition(0, this.row - 2);
                                Console.Write("Announce {0} [Y]/[N]?", possibleAnnounce.ToString());

                                var userInput = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(userInput))
                                {
                                    Console.WriteLine("Plase Enter [Y] or [N]");
                                    continue;
                                }

                                if (userInput[0] == 'N')
                                {
                                    possibleAnnounce = Announce.None;
                                }
                                else if (userInput[0] == 'Y')
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Plase Enter [Y] or [N]");
                                    continue;
                                }
                            }
                        }

                        playerAction = new PlayerAction(PlayerActionType.PlayCard, card, possibleAnnounce);
                    }
                }
                else if (userActionAsString[0] == 'T')
                {
                    playerAction = new PlayerAction(PlayerActionType.ChangeTrump, null, Announce.None);
                }
                else if (userActionAsString[0] == 'C')
                {
                    playerAction = new PlayerAction(PlayerActionType.CloseGame, null, Announce.None);
                }
                else
                {
                    Console.WriteLine("Invalid!     ");
                    continue;
                }

                if (actionValidater.IsValid(playerAction, context))
                {
                    this.PrintGameInfo(context);
                    return playerAction;
                }
                else
                {
                    Console.WriteLine("Invalid!     ");
                    continue;
                }
                Console.ReadLine();
            }

            throw new NotImplementedException();
        }

        private void PrintGameInfo(PlayerTurnContext context)
        {
            Console.SetCursorPosition(0,0);

            Console.WriteLine("Trump card: {0}", context.TrumpCard);

            Console.SetCursorPosition(0, 1);

            Console.WriteLine("Board: {0}-{1}", context.FirstPlayedCard, context.SecondPlayedCard);

            Console.SetCursorPosition(0, 2);

            Console.WriteLine("Game State: {0}", context.State.GetType().Name);

            Console.SetCursorPosition(0, 3);

            Console.WriteLine("Cards Left in Deck: {0}", context.CardsLeft);
        }
    }
}
