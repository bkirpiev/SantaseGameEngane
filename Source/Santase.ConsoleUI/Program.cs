namespace Santase.ConsoleUI
{
    using System;

    using Logic.Cards;
    using Logic.GameLogic;


    public static class Program
    {
        public static void Main(string[] args)
        {
            ISantaseGame game = new SantaseGame();

            game.Start();
            Console.WriteLine("Game finished!");
            Console.WriteLine("{0} - {1}", game.FirstPlayerTotalPoints, game.SecondPlayerTotalPoints);
        }
    }
}
