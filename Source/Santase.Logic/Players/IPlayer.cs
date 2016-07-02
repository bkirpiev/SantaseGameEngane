namespace Santase.Logic.Players
{
    using Cards;


    public interface IPlayer
    {
        void AddCard(Card card);

        PlayerAction GetTurn(PlayerTurnContext context);
    }
}
