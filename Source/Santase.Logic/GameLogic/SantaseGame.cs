namespace Santase.Logic.GameLogic
{
    using Players;


    public class SantaseGame : ISantaseGame
    {
        private int firstPlayerTotalPoints;
        private int secondPlayerTotalPoints;
        private int roundCount;
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private PlayerPosition firstToPlay;


        /// <summary>
        /// Това е клас, който също ще изисква двама играчи, за да се състой една игра
        /// Този, който създава истанцията на този клас, ще определя какви ще са играчите дали конзолни играчи, играчи по мрежата, изкуствен ителект
        /// И всеки от тях, който имплементира интерфейса IPlayer може да се подаде.
        /// </summary>
        public SantaseGame(IPlayer firstPlayer, IPlayer secondPlayer, PlayerPosition firstToPlay)
        {
            this.firstPlayerTotalPoints = 0;
            this.secondPlayerTotalPoints = 0;
            this.roundCount = 0;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.firstToPlay = firstToPlay;
        }

        public void Start()
        {
            while (!isGameFinished())
            {
                this.PlayRound();
                roundCount++;
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
            IGameRound round = new GameRound(this.firstPlayer, this.secondPlayer, this.firstToPlay);

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
                    this.firstToPlay = PlayerPosition.FirstPlayer;
                    return;
                }
            }

            if (round.ClosedByPlayer == PlayerPosition.SecondPlayer)
            {
                if (round.SecondPlayerPoints < 66)
                {
                    this.FirstPlayerTotalPoints += 3;
                    this.firstToPlay = PlayerPosition.SecondPlayer;
                    return;
                }
            }

            if (round.FirstPlayerPoints > round.SecondPlayerPoints)
            {
                if (round.SecondPlayerPoints >= 33)
                {
                    this.FirstPlayerTotalPoints += 1;
                    this.firstToPlay = PlayerPosition.SecondPlayer;
                }
                else if (round.SecondPlayerHasHand)
                {
                    this.FirstPlayerTotalPoints += 2;
                    this.firstToPlay = PlayerPosition.SecondPlayer;
                }
                else
                {
                    this.FirstPlayerTotalPoints += 3;
                    this.firstToPlay = PlayerPosition.SecondPlayer;
                }
            }
            else if (round.SecondPlayerPoints > round.FirstPlayerPoints)
            {
                if (round.FirstPlayerPoints >= 33)
                {
                    this.SecondPlayerTotalPoints += 1;
                    this.firstToPlay = PlayerPosition.FirstPlayer;
                }
                else if (round.SecondPlayerHasHand)
                {
                    this.SecondPlayerTotalPoints += 2;
                    this.firstToPlay = PlayerPosition.FirstPlayer;
                }
                else
                {
                    this.SecondPlayerTotalPoints += 3;
                    this.firstToPlay = PlayerPosition.FirstPlayer;
                }
            }
            else
            {
                // Когато двамта играчи имат еднакъв брой точки!
            }
        }

        public int RoundsPlayed
        {
            get
            {
                return this.roundCount;
            }
        }
    }
}
