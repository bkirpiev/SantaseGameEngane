namespace Santase.Logic.Players
{
    public interface IPlayerActionValidater
    {
        bool IsValid(PlayerAction action, PlayerTurnContext context);
    }
}
