namespace Santase.Logic.RoundStates
{
    using GameLogic;


    public class MoreThanTwoCardRoudState : BaseRoundState
    {
        public MoreThanTwoCardRoudState(IGameRound round)
            : base(round)
        {
        }

        public override bool CanAnnounce20or40
        {
            get { return true; }
        }

        public override bool CanClose
        {
            get { return true; }
        }

        public override bool CanChangeTrump
        {
            get { return true; }
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
            if (cardsLeftInDeck == 2)
            {
                this.round.SetState(new TwoCardLeftRoundState(round));
            }
        }
    }
}
