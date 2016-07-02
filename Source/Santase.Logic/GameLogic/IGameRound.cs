namespace Santase.Logic.GameLogic
{
    public interface IGameRound
    {
        void Start();

        /// <summary>
        /// Колко точки общо е спечелил първия играч за рунда
        /// </summary>
        int TotalPointsWonByFirstPlayer { get; }

        /// <summary>
        /// Колко точки общо е спечелил втория играч за рунда
        /// </summary>
        int TotalPointsWonBySecondPlayer { get; }
    }
}
