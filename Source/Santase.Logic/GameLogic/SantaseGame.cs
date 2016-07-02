namespace Santase.Logic.GameLogic
{
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
            UpdatePoints(round);
        }

        private void UpdatePoints(IGameRound round)
        {

            if (round.ClosedByPlayer == PlayerPosition.FirstPlayer)
            {
                if (round.FirstPlayerPoints < 66)
                {
                    this.SecondPlayerTotalPoints += 3;
                    return;
                }
            }

            if (round.ClosedByPlayer == PlayerPosition.ScondPlayer)
            {
                if (round.SecondPlayerPoints < 66)
                {
                    this.FirstPlayerTotalPoints += 3;
                    return;
                }
            }

            if (round.FirstPlayerPoints > round.SecondPlayerPoints)
            {
                if (round.SecondPlayerPoints >= 33)
                {
                    this.FirstPlayerTotalPoints += 1;
                }
                else if (round.SecondPlayerHasHand)
                {
                    this.FirstPlayerTotalPoints += 2;
                }
                else
                {
                    this.FirstPlayerTotalPoints += 3;
                }
            }
            else if (round.SecondPlayerPoints > round.FirstPlayerPoints)
            {
                if (round.FirstPlayerPoints >= 33)
                {
                    this.SecondPlayerTotalPoints += 1;
                }
                else if (round.SecondPlayerHasHand)
                {
                    this.SecondPlayerTotalPoints += 2;
                }
                else
                {
                    this.SecondPlayerTotalPoints += 3;
                }
            }
            else
            {
                // Когато двамта играчи имат еднакъв брой точки!
            }
        }

    }
}
