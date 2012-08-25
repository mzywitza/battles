using System;
using System.Collections.Generic;
using System.Globalization;

namespace Monastry.Battles.Core
{
    /// <summary>
    /// This class records the roll of a single die.
    /// </summary>
    public class DiceRoll : IEquatable<DiceRoll>
    {
        private static readonly Random Random = new Random();

        private readonly int _number;
        
        /// <summary>
        /// Creates a dice roll initialized with the given number
        /// </summary>
        /// <param name="number">The number must be between 1 and 6</param>
        /// <exception cref="ArgumentException">
        /// When trying to set the property to a value lower than 1 or higher than 6.
        /// </exception>
        public DiceRoll(int number)
        {
            if (number < 1 || number > 6) throw new ArgumentException("Number must be between 1 and 6","number");
            _number = number;
        }

        /// <summary>
        /// The number that the die has rolled. This number is always between 1 and 6.
        /// </summary>
        public int Number
        {
            get { return _number; }
        }

        /// <summary>
        /// Displays the roll as the number representated by the roll
        /// </summary>
        /// <returns>One of ["1","2","3","4","5","6"]</returns>
        public override string ToString()
        {
            return _number.ToString(CultureInfo.InvariantCulture);
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
                dice[i] = new DiceRoll(Random.Next(1, 7));
            }

            return dice;
        }

        public bool Equals(DiceRoll other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._number == _number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DiceRoll)) return false;
            return Equals((DiceRoll) obj);
        }

        public override int GetHashCode()
        {
            return _number;
        }

        public static bool operator ==(DiceRoll left, DiceRoll right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DiceRoll left, DiceRoll right)
        {
            return !Equals(left, right);
        }
    }
}