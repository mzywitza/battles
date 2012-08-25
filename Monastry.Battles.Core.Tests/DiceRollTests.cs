using System;
using System.Text;
using NUnit.Framework;

namespace Monastry.Battles.Core
{
    [TestFixture]
    public class DiceRollTests
    {
        [Test]
        public void DiceRollContainsNumber()
        {
            var roll = new DiceRoll() {Number = 4};
            Assert.That(roll.Number, Is.EqualTo(4));
        }

        [Test]
        public void CannotAssignNumberLowerThanOne()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll {Number = 0});
        }

        [Test]
        public void CannotAssignHigherNumberThanSix()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll() {Number = 7});
        }

        [Test]
        public void CanDisplayWithToString()
        {
            Assert.That((new DiceRoll{Number = 4}).ToString(),Is.EqualTo("4"));
        }

        [Test]
        public void EmptyRollDisplaysAsHyphen()
        {
            Assert.That((new DiceRoll()).ToString(),Is.EqualTo("-"));
        }

    }
}
