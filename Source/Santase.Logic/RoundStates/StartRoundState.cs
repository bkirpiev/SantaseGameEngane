namespace Santase.Logic.RoundStates
{
    using GameLogic;


    public class StartRoundState : BaseRoundState
    {
        public StartRoundState(IGameRound round)
            : base(round)
        {

        }

        public override bool CanAnnounce20or40
        {
            get
            {
                return false;
            }
        }

        public override bool CanClose
        {
            get { return false; }
        }

        public override bool CanChangeTrump
        {
            get { return false; }
        }

        /// <summary>
        /// Правилата се спазват само когато е свършена играта
        /// </summary>
        public override bool ShouldObserveRules
        {
            get { return false; }
        }

        /// <summary>
        /// След първата ръка която съм изиграл мога да изтегля карта
        /// </summary>
        public override bool ShouldDrawCard
        {
            get { return true; }
        }

        internal override void PlayHand(int cardsLeftInDeck)
        {
            this.round.SetState(new MoreThanTwoCardRoudState(this.round));
        }
    }
}
