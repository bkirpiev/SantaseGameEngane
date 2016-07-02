namespace Santase.Logic.Extensions
{
    using System;


    /// <summary>
    /// Static class representing a single instance of the Random class!
    /// С този клас правя само една единствена инстанция на клас Random, понеже ако всеки път правя нова инстанция на класа, ще ми връща едно и също число, защто се създават.
    /// в рамките на една и съща милисекунда, а тя е един от параметрите, с които се генерира това рандом число.
    /// </summary>
    public static class RandomProvider
    {
        private static Random instance;

        /// <summary>
        /// The instance of the random class
        /// </summary>
        /// <value>
        /// The instance of the random class
        /// </value>
        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random();
                }

                return instance;
            }
        }
    }
}
