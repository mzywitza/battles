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
            var roll = new DiceRoll(4);
            Assert.That(roll.Number, Is.EqualTo(4));
        }

        [Test]
        public void CannotAssignNumberLowerThanOne()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll(0));
        }

        [Test]
        public void CannotAssignHigherNumberThanSix()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll(7));
        }

        [Test]
        public void CanDisplayWithToString()
        {
            Assert.That((new DiceRoll(4)).ToString(),Is.EqualTo("4"));
        }

        [Test]
        public void DiceRollsAreEquatable()
        {
            Assert.That(new DiceRoll(2), Is.EqualTo(new DiceRoll(2)));
            Assert.That(new DiceRoll(3) == new DiceRoll(3));
        }

        [Test]
        public void DiceRollsAreComparable()
        {
            var r1 = new DiceRoll(2);
            var r2 = new DiceRoll(3);
            var r3 = new DiceRoll(3);
            Assert.That(r1.CompareTo(r2), Is.LessThan(0));
            Assert.That(r2.CompareTo(r1), Is.GreaterThan(0));
            Assert.That(r2.CompareTo(r3), Is.EqualTo(0));
        }

        [Test]
        public void DiceRollsCanBeComparedWithOperators()
        {
            var r1 = new DiceRoll(2);
            var r2 = new DiceRoll(3);
            var r3 = new DiceRoll(3);
            Assert.That(r1 < r2);            
            Assert.That(r1 <= r2);            
            Assert.That(r2 > r1);            
            Assert.That(r2 >= r1);
            Assert.That(r2 >= r3);
            Assert.That(r2 <= r3);
            Assert.That(r3 >= r2);
            Assert.That(r3 <= r2);
        }

    }
}
