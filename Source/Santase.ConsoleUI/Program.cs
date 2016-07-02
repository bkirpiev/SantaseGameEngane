namespace Santase.ConsoleUI
{
    using System;

    using Logic.Cards;


    public static class Program
    {
        public static void Main(string[] args)
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                Console.WriteLine(deck.GetNextCard());
            }
        }
    }
}
