namespace Santase.Logic.Cards
{
    // Всяко нещо което ще бъде тесте искам да има следните неща
    // По коцепция разграничаваме, пропъртира и методи
    // Пишем пропърти когато два пъти последователно извиквайки пропъртито ще получим една и съща стойност
    // В случая GetTrumpCard, ще се променя много рядко
    public interface IDeck
    {
        /// <summary>
        /// Взимане на следваща карта
        /// </summary>
        /// <returns></returns>
        Card GetNextCard();

        /// <summary>
        /// Козова карта
        /// </summary>
        Card GetTrumpCard { get; }

        /// <summary>
        /// Смяна на козовата карта
        /// </summary>
        /// <param name="newCard"></param>
        void ChangeTrumpCard(Card newCard);
    }
}
