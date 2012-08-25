using System;

namespace Monastry.Battles.Core
{
    /// <summary>
    /// This class records the roll of a single die.
    /// </summary>
    public class DiceRoll
    {

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
    }
}