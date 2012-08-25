using System;
using System.Collections.Generic;
using System.Globalization;

namespace Monastry.Battles.Core
{
    /// <summary>
    /// This class records the roll of a single die.
    /// </summary>
    public class DiceRoll
    {
        private static readonly Random Random = new Random();

        private int? _number;
        
        /// <summary>
        /// The number the die has rolled. If the value is <c>null</c>, no roll is recorded so far.
        /// The value must be either <c>null</c> or a number between 1 and 6.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// When trying to set the property to a value lower than 1 or higher than 6.
        /// </exception>
        public int? Number
        {
            get { return _number; }
            set
            {
                if (value < 1 || value > 6) throw new ArgumentException("Number must be between 1 and 6");
                _number = value;
            }
        }

        /// <summary>
        /// Displays the roll as the number representated by the roll or as a hyphen when no number is
        /// recorded so far.
        /// </summary>
        /// <returns>One of ["-","1","2","3","4","5","6"]</returns>
        public override string ToString()
        {
            return Number.HasValue ? Number.Value.ToString(CultureInfo.InvariantCulture) : "-";
        }

        /// <summary>
        /// Returns an enumeration with the number of dice requested by the parameter. All dice are 
        /// initialized with a random number between 1 and 6.
        /// </summary>
        /// <param name="numberOfDice">The number of dice to roll.</param>
        /// <returns>an array of dice rolls</returns>
        public static IEnumerable<DiceRoll> Roll(int numberOfDice)
        {
            var dice = new DiceRoll[numberOfDice];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new DiceRoll() {Number = Random.Next(1, 7)};
            }

            return dice;
        }
    }
}