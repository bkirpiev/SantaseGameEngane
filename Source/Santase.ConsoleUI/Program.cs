namespace Santase.ConsoleUI
{
    using System;

    using Logic.GameLogic;


    public static class Program
    {
        public static void Main(string[] args)
        {
            ISantaseGame game = new SantaseGame(new ConsolePlayer(6, 10), new ConsolePlayer(15, 10), PlayerPosition.FirstPlayer);

            game.Start();
            Console.WriteLine("Game finished!");
            Console.WriteLine("{0} - {1}", game.FirstPlayerTotalPoints, game.SecondPlayerTotalPoints);
            Console.WriteLine("Rounds Played: {0}", game.RoundsPlayed);
        }
    }
}
