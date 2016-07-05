namespace Santase.Logic.RoundStates
{
    using GameLogic;


    public class TwoCardLeftRoundState : BaseRoundState
    {
        public TwoCardLeftRoundState(IGameRound round)
            : base(round)
        {
        }

        public override bool CanAnnounce20or40
        {
            get { return true; }
        }

        public override bool CanClose
        {
            get { return false; }
        }

        public override bool CanChangeTrump
        {
            get { return false; }
        }

        public override bool ShouldObserveRules
        {
            get { return false; }
        }

        public override bool ShouldDrawCard
        {
            get { return true; }
        }

        internal override void PlayHand(int cardsLeftInDeck)
        {
            if (cardsLeftInDeck == 0)
            {
                this.round.SetState(new FinalRoundState(round));
            }
        }
    }
}
