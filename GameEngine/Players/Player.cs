using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameEngine.Players
{
    /// <summary>
    /// Represents the base class for all available players.
    /// </summary>
    public abstract class Player
    {
        public ObservableCollection<int> Attempts { get; set; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        internal abstract int TryGuessWeight(int minValue, int maxValue, List<int> globalAttempts);

        internal virtual void PrepareForTheNextGame()
        {
            Attempts.Clear();
        }

        protected Player(string name)
        {
            Name = name;
            Attempts = new ObservableCollection<int>();
        }
    }
}