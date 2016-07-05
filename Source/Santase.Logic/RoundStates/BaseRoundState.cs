namespace Santase.Logic.RoundStates
{
    using GameLogic;


    public abstract class BaseRoundState
    {
        protected IGameRound round;

        protected BaseRoundState(IGameRound round)
        {
            this.round = round;
        }

        public abstract bool CanAnnounce20or40 { get; }

        public abstract bool CanClose { get; }

        public abstract bool CanChangeTrump { get; }

        public abstract bool ShouldObserveRules { get; }

        public abstract bool ShouldDrawCard { get; }

        /// <summary>
        /// Спрямо това колко карти са останали в играта може да се определи състоянието на играта
        /// </summary>
        /// <param name="cardsLeftInDeck"></param>
        internal abstract void PlayHand(int cardsLeftInDeck);

        internal void Close()
        {
            if (this.CanClose)
            {
                round.SetState(new FinalRoundState(round));
            }
        }
    }
}
