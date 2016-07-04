namespace Santase.Logic.Players
{
    using Cards;


    public class PlayerAction
    {
        public Card PlayCard { get; private set; }

        public PlayerActionType Type { get; private set; }

        public Announce Announce { get; private set; }


        public PlayerAction(PlayerActionType type, Card card, Announce announce)
        {
            this.Type = type;
            this.PlayCard = card;
            this.Announce = announce;
        }
    }
}
