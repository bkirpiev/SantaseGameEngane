namespace Santase.Logic.GameLogic
{
    using System;

    using Cards;

    using Players;

    using RoundStates;


    public class GameHand : IGameHand
    {
        private PlayerPosition whoWillPlayFirst;
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private BaseRoundState state;

        public GameHand(PlayerPosition whoWillPlayFirst, IPlayer firstPlayer, IPlayer secondPlayer, BaseRoundState state)
        {
            this.whoWillPlayFirst = whoWillPlayFirst;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.state = state;
        }

        public void Start()
        {
            IPlayer firstToPlay;
            IPlayer secondToPlay;

            if (whoWillPlayFirst == PlayerPosition.FirstPlayer)
            {
                firstToPlay = this.firstPlayer;
                secondToPlay = this.secondPlayer;
            }
            else
            {
                firstToPlay = this.secondPlayer;
                secondToPlay = this.firstPlayer;
            }

            PlayerAction firstFirstPlayerAction = null;

            do
            {
                firstFirstPlayerAction = this.FirstPlayerTurn(firstToPlay);
            } while (firstFirstPlayerAction.Type != PlayerActionType.PlayCard);

            PlayerAction secondFirstPlayerAction = firstToPlay.GetTurn(new PlayerTurnContext());
            //TODO: turn == close => close, change state, ask first
            //TODO: turn == trumpChange => change, ask, first

            var secondToPlayTurn = secondToPlay.GetTurn(new PlayerTurnContext());

            // Determine who wins the hand
        }

        public PlayerPosition Winner
        {
            get { throw new System.NotImplementedException(); }
        }

        public Card FirstPlayerCard
        {
            get { throw new System.NotImplementedException(); }
        }

        public Announce FirstPlayerAnnounce
        {
            get { throw new System.NotImplementedException(); }
        }

        public Card SecondPlayerCard
        {
            get { throw new System.NotImplementedException(); }
        }

        public Announce SecondPlayerAnnounce
        {
            get { throw new System.NotImplementedException(); }
        }

        public PlayerPosition GameClosedBy
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// True - карта е изиграна, False обявява друг announce;
        /// </summary>
        /// <param name="firstToPlay"></param>
        /// <returns></returns>
        private PlayerAction FirstPlayerTurn(IPlayer firstToPlay)
        {
            var firstToPlayTurn = firstToPlay.GetTurn(new PlayerTurnContext());

            if (firstToPlayTurn.Type == PlayerActionType.CloseGame)
            {
                this.state.Close();
                // who closed game;
                return firstToPlayTurn;
            }

            if (firstToPlayTurn.Type == PlayerActionType.ChangeTrump)
            {
                return firstToPlayTurn;
            }

            if (firstToPlayTurn.Type == PlayerActionType.PlayCard)
            {
                return firstToPlayTurn;
            }

            return firstToPlayTurn;
        }



    }
}
