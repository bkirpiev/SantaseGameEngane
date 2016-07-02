namespace Santase.Logic.GameLogic
{
    using System;
    using System.Runtime.InteropServices.ComTypes;


    public class SantaseGame : ISantaseGame
    {
        private int firstPlayerTotalPoints;
        private int secondPlayerTotalPoints;

        public SantaseGame()
        {
            this.firstPlayerTotalPoints = 0;
            this.secondPlayerTotalPoints = 0;
        }

        public void Start()
        {
            while (!isGameFinished())
            {
                this.PlayRound();
            }
        }

        public int FirstPlayerTotalPoints
        {
            get
            {
                return this.firstPlayerTotalPoints;
            }
            private set
            {
                this.firstPlayerTotalPoints = value;
            }
        }

        public int SecondPlayerTotalPoints
        {
            get
            {
                return this.secondPlayerTotalPoints;
            }
            private set
            {
                this.secondPlayerTotalPoints = value;
            }
        }

        /// <summary>
        /// Приключила е играта когато някой от играчите е направил повече от 11 точки
        /// </summary>
        /// <returns></returns>
        private bool isGameFinished()
        {
            return this.FirstPlayerTotalPoints >= 11 || this.SecondPlayerTotalPoints >= 11;
        }

        private void PlayRound()
        {
            IGameRound round = new GameRound();

            round.Start();
            this.FirstPlayerTotalPoints += round.TotalPointsWonByFirstPlayer;

            this.SecondPlayerTotalPoints += round.TotalPointsWonBySecondPlayer;
        }
    }
}
