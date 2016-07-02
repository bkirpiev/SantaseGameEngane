namespace Santase.Logic.GameLogic
{
    using System;
    using System.Collections.Generic;

    using Cards;

    using Players;


    public class GameRound : IGameRound
    {
        private IDeck deck;

        private IPlayer firstPlayer;
        private int firstPlayerPoints;
        private IList<Card> firstPlayerCards;
        private IList<Card> firstPlayerCollectedCards;

        private IPlayer secondPlayer;
        private int secondPlayerPoints;
        private IList<Card> secondPlayerCards;
        private IList<Card> secondPlayerCollectedCards;

        private PlayerPosition firstToPlay;

        /// <summary>
        /// Никой не може да направи инстанция на играта, докато не ми подаде двама играчи
        /// </summary>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        public GameRound(IPlayer firstPlayer, IPlayer secondPlayer, PlayerPosition firstToPlay)
        {
            this.deck = new Deck();

            this.firstPlayer = firstPlayer;
            this.firstPlayerPoints = 0;
            this.firstPlayerCards = new List<Card>();
            this.firstPlayerCollectedCards = new List<Card>();

            this.secondPlayer = secondPlayer;
            this.secondPlayerPoints = 0;
            this.secondPlayerCards = new List<Card>();
            this.secondPlayerCollectedCards = new List<Card>();

            this.firstToPlay = firstToPlay;
        }

        public void Start()
        {
            DealFirstCards();

            while (!this.IsFinished())
            {
                // PlayHand();

            }
        }

        /// <summary>
        /// Раздаване на картите
        /// </summary>
        private void DealFirstCards()
        {
            for (int i = 0; i < 3; i++)
            {
                var card = this.deck.GetNextCard();
                this.firstPlayer.AddCard(card);
            }

            for (int i = 0; i < 3; i++)
            {
                var card = this.deck.GetNextCard();
                this.secondPlayer.AddCard(card);
            }

            for (int i = 0; i < 3; i++)
            {
                var card = this.deck.GetNextCard();
                this.firstPlayer.AddCard(card);
            }

            for (int i = 0; i < 3; i++)
            {
                var card = this.deck.GetNextCard();
                this.secondPlayer.AddCard(card);
            }
        }

        private bool IsFinished()
        {
            if (this.firstPlayerPoints >= 66 || this.secondPlayerPoints >= 66)
            {
                return true;
            }

            if (this.firstPlayerCards.Count == 0 || this.secondPlayerCards.Count == 0)
            {
                return true;
            }

            return false;
        }

        private void PlayHand()
        {
            IGameHand hand = new GameHand();
            hand.Start();

            this.firstToPlay = hand.Winner;
            // TODO: Update points
            // TODO: Add one more card to both players
            // TODO: Update collected cards for both players;
        }

        public int FirstPlayerPoints
        {
            get
            {
                return this.firstPlayerPoints;
            }
        }

        public int SecondPlayerPoints
        {
            get
            {
                return this.secondPlayerPoints;
            }
        }

        public bool FirstPlayerHasHand
        {
            get { return this.firstPlayerCollectedCards.Count > 0; }
        }

        public bool SecondPlayerHasHand
        {
            get
            {
                return this.secondPlayerCollectedCards.Count > 0;
            }
        }

        public PlayerPosition ClosedByPlayer
        {
            get { throw new NotImplementedException(); }
        }
    }
}
