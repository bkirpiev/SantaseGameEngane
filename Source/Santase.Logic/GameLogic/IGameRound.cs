namespace Santase.Logic.GameLogic
{
    using RoundStates;


    public interface IGameRound
    {
        void Start();

        /// <summary>
        /// Колко точки общо е спечелил първия играч за рунда
        /// </summary>
        int FirstPlayerPoints { get; }

        /// <summary>
        /// Колко точки общо е спечелил втория играч за рунда
        /// </summary>
        int SecondPlayerPoints { get; }

        /// <summary>
        /// Първия играч взел ли е ръка
        /// </summary>
        bool FirstPlayerHasHand { get; }

        /// <summary>
        /// Втория играч взел ли е ръка
        /// </summary>
        bool SecondPlayerHasHand { get; }

        /// <summary>
        /// Взимам играча, който е затворил играта
        /// </summary>
        PlayerPosition ClosedByPlayer { get; }

        void SetState(BaseRoundState newState);
    }
}
