namespace Santase.Logic.GameLogic
{
    public interface ISantaseGame
    {
        /// <summary>
        /// Започвае на играта
        /// </summary>
        void Start();

        /// <summary>
        /// Точките на първия играч
        /// </summary>
        int FirstPlayerTotalPoints { get; }

        /// <summary>
        /// Точките на втория играч
        /// </summary>
        int SecondPlayerTotalPoints { get; }
    }
}
