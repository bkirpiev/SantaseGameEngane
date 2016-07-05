namespace Santase.Logic.Players
{
    public class PlayerActionValidator : IPlayerActionValidater
    {
        public bool IsValid(PlayerAction action, PlayerTurnContext context)
        {
           return false;
        }
    }
}
