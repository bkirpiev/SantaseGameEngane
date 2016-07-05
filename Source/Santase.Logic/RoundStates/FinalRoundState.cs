namespace Santase.Logic.RoundStates
{
    using GameLogic;


    public class FinalRoundState : BaseRoundState
    {
        public FinalRoundState(IGameRound round)
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
            get { return true; }
        }

        public override bool ShouldDrawCard
        {
            get { return false; }
        }

        internal override void PlayHand(int cardsLeftInDeck)
        {
        }
    }
}
